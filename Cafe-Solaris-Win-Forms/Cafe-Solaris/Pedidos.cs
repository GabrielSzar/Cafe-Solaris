using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Solaris
{
    internal class Pedidos
    {
        public int id { get; set; }
        public int cliente_id { get; set; }
        public int entregador_id { get; set; }
        public DateTime data_pedido { get; set; }
        public string status { get; set; }
        public string obs { get; set; }
        public string forma_pg { get; set; }
        public decimal taxa_entrega { get; set; }


        //Criação dos métodos do CRUD.
        //1º PASSO: instanciar a classe de CONEXÃO.

        Conexao db = new Conexao();

        public void InserirPedido()
        {
            string inserir = $"INSERT INTO pedidos VALUES(null,'{cliente_id}', '{entregador_id}', '{data_pedido}', '{status}', '{obs}','{forma_pg}', '{taxa_entrega}')";
            db.ExecutarComando(inserir);
        }



        public void AlterarPedido()
        {
            string alterar = $"UPDATE pedidos SET cliente_id = '{cliente_id}', entregador_id = '{entregador_id}', data_pedido = '{data_pedido}', status = '{status}', observacoes = '{obs}', forma_pagamento = '{forma_pg}', taxa_entrega = '{taxa_entrega}'  WHERE id = '{id}'";
            db.ExecutarComando(alterar);
        }

        public void ExcluirPedido()
        {
            string excluir = $"DELETE FROM pedidos WHERE id = '{id}'";
            db.ExecutarComando(excluir);
        }


        public DataTable ListarPedido()
        {
            string listarTodos = "SELECT * FROM pedidos ORDER BY id;";
            return db.ExecutarConsulta(listarTodos);
        }

    }
}
