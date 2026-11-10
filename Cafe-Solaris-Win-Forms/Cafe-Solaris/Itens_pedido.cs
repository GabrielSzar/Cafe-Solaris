using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cafe_Solaris
{
    internal class Itens_pedido
    {
        public int id { get; set; }
        public int pedido_id { get; set; }
        public int produto_id { get; set; }
        public int qtd { get; set; }
        public decimal preco_unitario { get; set; }


        //Criação dos métodos do CRUD.
        //1º PASSO: instanciar a classe de CONEXÃO.

        Conexao db = new Conexao();

        public void InserirItens_pedido()
        {
            string inserir = $"INSERT INTO itens_pedido VALUES(null,'{pedido_id}', '{produto_id}', '{qtd}', '{preco_unitario}')";
            db.ExecutarComando(inserir);
        }

  

        public void AlterarItens_pedido()
        {
            string alterar = $"UPDATE itens_pedido SET pedido_id = '{pedido_id}', produto_id = '{produto_id}', qtd = '{qtd}', preco_unitario = '{preco_unitario}' WHERE id = '{id}'";
            db.ExecutarComando(alterar);
        }

        public void ExcluirItens_pedido()
        {
            string excluir = $"DELETE FROM itens_pedido WHERE id = '{id}'";
            db.ExecutarComando(excluir);
        }


        public DataTable ListarItens_pedido()
        {
            string listarTodos = "SELECT * FROM itens_pedido ORDER BY id;";
            return db.ExecutarConsulta(listarTodos);
        }

    }
}
