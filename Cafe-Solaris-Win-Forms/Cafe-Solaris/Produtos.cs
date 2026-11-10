using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Solaris
{
    internal class Produtos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string categoria { get; set; }
        public decimal preco { get; set; }


        //Criação dos métodos do CRUD.
        //1º PASSO: instanciar a classe de CONEXÃO.

        Conexao db = new Conexao();

        public void InserirProduto()
        {
            string inserir = $"INSERT INTO produtos (nome, descricao, preco, categoria) VALUES('{nome}', '{descricao}', '{preco}', '{categoria}')";
            db.ExecutarComando(inserir);
        }



        public void AlterarProduto()
        {
            string alterar = $"UPDATE produtos SET nome = '{nome}', descricao = '{descricao}', preco = '{preco}', categoria = '{categoria}' WHERE id = '{id}'";
            db.ExecutarComando(alterar);
        }


        public void ExcluirProduto()
        {
            string excluir = $"DELETE FROM produtos WHERE id = '{id}'";
            db.ExecutarComando(excluir);
        }


        public DataTable ListarProdutos()
        {
            string listarTodos = "SELECT * FROM produtos ORDER BY nome;";
            return db.ExecutarConsulta(listarTodos);
        }



    }
}
