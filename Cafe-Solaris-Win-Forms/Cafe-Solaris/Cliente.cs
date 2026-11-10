    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Solaris
{
    internal class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string numero_tel { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string comp_endereco { get; set; }



        //Criação dos métodos do CRUD.
        //1º PASSO: instanciar a classe de CONEXÃO.

        Conexao db = new Conexao();

        internal static string PrepararSenha(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.StartsWith("PBKDF2-SHA256$"))
            {
                return valor;
            }

            const int iteracoes = 100000;
            byte[] salt = new byte[16];

            using (var gerador = RandomNumberGenerator.Create())
            {
                gerador.GetBytes(salt);
            }

            using (var derivador = new Rfc2898DeriveBytes(valor, salt, iteracoes, HashAlgorithmName.SHA256))
            {
                byte[] hash = derivador.GetBytes(32);
                return $"PBKDF2-SHA256${iteracoes}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
            }
        }

        public void InserirCliente()
        {
            string inserir = $"INSERT INTO clientes (nome, senha, numero_telefone, email, cpf, cep, bairro, rua, numero, complemento_endereco) VALUES('{nome}', '{PrepararSenha(senha)}', '{numero_tel}', '{email}', '{cpf}', '{cep}', '{bairro}', '{rua}', '{numero}', '{comp_endereco}')";
            db.ExecutarComando(inserir);
        }

        public void AlterarCliente()
        {
            string senhaSql = string.IsNullOrWhiteSpace(senha) ? "" : $", senha = '{PrepararSenha(senha)}'";
            string alterar = $"UPDATE clientes SET nome = '{nome}'{senhaSql}, numero_telefone = '{numero_tel}', email = '{email}', cpf = '{cpf}', cep = '{cep}', bairro = '{bairro}', rua = '{rua}', numero = '{numero}', complemento_endereco = '{comp_endereco}' WHERE id = '{id}'";
            db.ExecutarComando(alterar);
        }

        public void ExcluirCliente()
        {
            string excluir = $"DELETE FROM clientes WHERE id = '{id}'";
            db.ExecutarComando(excluir);
        }


        public DataTable ListarCliente()
        {
            string listarTodos = "SELECT * FROM clientes ORDER BY id;";
            return db.ExecutarConsulta(listarTodos);
        }

    }
}
