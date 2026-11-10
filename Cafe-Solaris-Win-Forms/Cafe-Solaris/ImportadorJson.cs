using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cafe_Solaris
{
    internal enum TipoCampo
    {
        Texto,
        Inteiro,
        Dinheiro,
        Data
    }

    //Descreve uma coluna que o JSON pode trazer
    internal class Campo
    {
        public string Nome { get; set; }
        public TipoCampo Tipo { get; set; }
        public bool Obrigatorio { get; set; }
        public int Tamanho { get; set; }                      //só para texto (0 = sem limite)
        public object Padrao { get; set; }                    //valor usado quando o campo não vem no JSON
        public string TabelaReferencia { get; set; }          //chave estrangeira: o id precisa existir nessa tabela
        public Func<string, string> Transformar { get; set; } //ex.: gerar o hash da senha
    }

    //Descreve uma tabela: quais colunas o JSON preenche e como evitar duplicados
    internal class DefinicaoTabela
    {
        public string Nome { get; set; }
        public List<Campo> Campos { get; set; }
        public string[] ColunasUnicas { get; set; } = new string[0]; //se o valor já existir, o registro é pulado
    }

    internal class ResultadoImportacao
    {
        public int Inseridos { get; set; }
        public int Ignorados { get; set; }
    }

    internal class ImportadorJson
    {
        private readonly Conexao db = new Conexao();

        public ResultadoImportacao Importar(string tabela, string caminhoArquivo)
        {
            DefinicaoTabela definicao = Tabelas.Obter(tabela);
            string conteudo = File.ReadAllText(caminhoArquivo, Encoding.UTF8);

            JArray itens;
            try
            {
                itens = JArray.Parse(conteudo);
            }
            catch (JsonException ex)
            {
                throw new Exception("O arquivo precisa ser uma lista JSON de objetos.\n" + ex.Message);
            }

            if (itens.Count == 0)
            {
                throw new Exception("O arquivo não contém nenhum registro.");
            }

            //Passo 1: converte e valida tudo ANTES de gravar (as tabelas são MyISAM, sem rollback)
            List<Dictionary<string, object>> linhas = new List<Dictionary<string, object>>();
            for (int i = 0; i < itens.Count; i++)
            {
                JObject objeto = itens[i] as JObject;
                if (objeto == null)
                {
                    throw new Exception($"Item {i + 1}: cada item precisa ser um objeto JSON.");
                }

                linhas.Add(LerLinha(definicao, objeto, i + 1));
            }

            ResultadoImportacao resultado = new ResultadoImportacao();

            db.ExecutarEmTransacao((conn, tx) =>
            {
                //Passo 2: confere se as chaves estrangeiras existem (ex.: cliente_id) antes de gravar
                for (int i = 0; i < linhas.Count; i++)
                {
                    ConferirReferencias(conn, tx, definicao, linhas[i], i + 1);
                }

                //Passo 3: insere, pulando registros que já existem (inclusive repetidos dentro do próprio arquivo)
                foreach (Dictionary<string, object> linha in linhas)
                {
                    if (ExisteDuplicado(conn, tx, definicao, linha))
                    {
                        resultado.Ignorados++;
                        continue;
                    }

                    Inserir(conn, tx, definicao, linha);
                    resultado.Inseridos++;
                }
            });

            return resultado;
        }

        private static Dictionary<string, object> LerLinha(DefinicaoTabela definicao, JObject objeto, int numero)
        {
            Dictionary<string, object> valores = new Dictionary<string, object>();

            foreach (Campo campo in definicao.Campos)
            {
                JToken token = objeto.GetValue(campo.Nome, StringComparison.OrdinalIgnoreCase);
                object valor = ConverterValor(campo, token, numero);

                if (valor == null && campo.Obrigatorio)
                {
                    throw new Exception($"Item {numero}: '{campo.Nome}' é obrigatório.");
                }

                if (valor is string texto)
                {
                    if (campo.Tamanho > 0 && texto.Length > campo.Tamanho)
                    {
                        throw new Exception($"Item {numero}: '{campo.Nome}' passa de {campo.Tamanho} caracteres.");
                    }

                    if (campo.Transformar != null)
                    {
                        valor = campo.Transformar(texto);
                    }
                }

                if (valor is decimal dinheiro && (dinheiro < 0 || dinheiro > 99999999.99m))
                {
                    throw new Exception($"Item {numero}: '{campo.Nome}' está fora da faixa permitida.");
                }

                valores[campo.Nome] = valor;
            }

            return valores;
        }

        private static object ConverterValor(Campo campo, JToken token, int numero)
        {
            //Campo ausente, null ou vazio: usa o padrão da coluna (que pode ser null)
            if (token == null || token.Type == JTokenType.Null ||
                (token.Type == JTokenType.String && string.IsNullOrWhiteSpace(token.ToString())))
            {
                return campo.Padrao;
            }

            try
            {
                switch (campo.Tipo)
                {
                    case TipoCampo.Inteiro:
                        return token.Value<int>();
                    case TipoCampo.Dinheiro:
                        return token.Value<decimal>();
                    case TipoCampo.Data:
                        return token.Value<DateTime>();
                    default:
                        return token.ToString().Trim();
                }
            }
            catch (Exception)
            {
                throw new Exception($"Item {numero}: valor inválido em '{campo.Nome}' ({token}).");
            }
        }

        private static void ConferirReferencias(MySqlConnection conn, MySqlTransaction tx,
            DefinicaoTabela definicao, Dictionary<string, object> linha, int numero)
        {
            foreach (Campo campo in definicao.Campos)
            {
                object id = linha[campo.Nome];
                if (campo.TabelaReferencia == null || id == null)
                {
                    continue;
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    $"SELECT COUNT(*) FROM {campo.TabelaReferencia} WHERE id = @id", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    if (Convert.ToInt64(cmd.ExecuteScalar()) == 0)
                    {
                        throw new Exception(
                            $"Item {numero}: {campo.Nome} = {id} não existe na tabela {campo.TabelaReferencia}.");
                    }
                }
            }
        }

        private static bool ExisteDuplicado(MySqlConnection conn, MySqlTransaction tx,
            DefinicaoTabela definicao, Dictionary<string, object> linha)
        {
            foreach (string coluna in definicao.ColunasUnicas)
            {
                object valor = linha[coluna];
                if (valor == null)
                {
                    continue;
                }

                using (MySqlCommand cmd = new MySqlCommand(
                    $"SELECT COUNT(*) FROM {definicao.Nome} WHERE {coluna} = @valor", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@valor", valor);

                    if (Convert.ToInt64(cmd.ExecuteScalar()) > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void Inserir(MySqlConnection conn, MySqlTransaction tx,
            DefinicaoTabela definicao, Dictionary<string, object> linha)
        {
            //O id não entra aqui: o banco gera sozinho (AUTO_INCREMENT)
            string colunas = string.Join(", ", definicao.Campos.Select(c => c.Nome));
            string parametros = string.Join(", ", definicao.Campos.Select(c => "@" + c.Nome));

            using (MySqlCommand cmd = new MySqlCommand(
                $"INSERT INTO {definicao.Nome} ({colunas}) VALUES ({parametros})", conn, tx))
            {
                foreach (Campo campo in definicao.Campos)
                {
                    cmd.Parameters.AddWithValue("@" + campo.Nome, linha[campo.Nome] ?? DBNull.Value);
                }

                cmd.ExecuteNonQuery();
            }
        }
    }

    //Uma definição por tabela. Os nomes das colunas são os mesmos do cafe_solaris.sql.
    internal static class Tabelas
    {
        public static DefinicaoTabela Obter(string tabela)
        {
            switch (tabela)
            {
                case "produtos":
                    return new DefinicaoTabela
                    {
                        Nome = "produtos",
                        ColunasUnicas = new[] { "nome" },
                        Campos = new List<Campo>
                        {
                            Texto("nome", 100, obrigatorio: true),
                            Texto("descricao", 0),
                            Texto("categoria", 50, obrigatorio: true),
                            Dinheiro("preco", obrigatorio: true)
                        }
                    };

                case "clientes":
                    return new DefinicaoTabela
                    {
                        Nome = "clientes",
                        ColunasUnicas = new[] { "email", "cpf" },
                        Campos = new List<Campo>
                        {
                            Texto("nome", 100, obrigatorio: true),
                            Texto("numero_telefone", 20),
                            Texto("email", 100),
                            Texto("cpf", 14),
                            Texto("cep", 10),
                            Texto("bairro", 100),
                            Texto("rua", 150),
                            Texto("numero", 20),
                            Texto("complemento_endereco", 100),
                            Texto("senha", 120, transformar: Cliente.PrepararSenha)
                        }
                    };

                case "entregadores":
                    return new DefinicaoTabela
                    {
                        Nome = "entregadores",
                        ColunasUnicas = new[] { "cpf", "email" },
                        Campos = new List<Campo>
                        {
                            Texto("nome", 100, obrigatorio: true),
                            Texto("numero_telefone", 20),
                            Texto("cpf", 14),
                            Texto("rg", 20),
                            Texto("cep", 10),
                            Texto("email", 100)
                        }
                    };

                case "pedidos":
                    return new DefinicaoTabela
                    {
                        Nome = "pedidos",
                        Campos = new List<Campo>
                        {
                            Inteiro("cliente_id", obrigatorio: true, referencia: "clientes"),
                            Inteiro("entregador_id", referencia: "entregadores"),
                            DataHora("data_pedido", padrao: DateTime.Now),
                            Texto("status", 50, padrao: "Recebido"),
                            Texto("observacoes", 0),
                            Texto("forma_pagamento", 50),
                            Dinheiro("taxa_entrega")
                        }
                    };

                case "itens_pedido":
                    return new DefinicaoTabela
                    {
                        Nome = "itens_pedido",
                        Campos = new List<Campo>
                        {
                            Inteiro("pedido_id", obrigatorio: true, referencia: "pedidos"),
                            Inteiro("produto_id", obrigatorio: true, referencia: "produtos"),
                            Inteiro("qtd", obrigatorio: true),
                            Dinheiro("preco_unitario", obrigatorio: true)
                        }
                    };
            }

            throw new ArgumentException($"Tabela '{tabela}' não suportada.");
        }

        private static Campo Texto(string nome, int tamanho, bool obrigatorio = false,
            object padrao = null, Func<string, string> transformar = null)
        {
            return new Campo
            {
                Nome = nome,
                Tipo = TipoCampo.Texto,
                Tamanho = tamanho,
                Obrigatorio = obrigatorio,
                Padrao = padrao,
                Transformar = transformar
            };
        }

        private static Campo Inteiro(string nome, bool obrigatorio = false, string referencia = null)
        {
            return new Campo
            {
                Nome = nome,
                Tipo = TipoCampo.Inteiro,
                Obrigatorio = obrigatorio,
                TabelaReferencia = referencia
            };
        }

        private static Campo Dinheiro(string nome, bool obrigatorio = false)
        {
            return new Campo { Nome = nome, Tipo = TipoCampo.Dinheiro, Obrigatorio = obrigatorio };
        }

        private static Campo DataHora(string nome, object padrao = null)
        {
            return new Campo { Nome = nome, Tipo = TipoCampo.Data, Padrao = padrao };
        }
    }
}
