using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Solaris
{
    internal class Entregadores
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string numero_tel { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string cep { get; set; }
        public string email { get; set; }





        //Criação dos métodos do CRUD.
        //1º PASSO: instanciar a classe de CONEXÃO.

        Conexao db = new Conexao();

        public void InserirEntregadores()
        {
            string inserir = $"INSERT INTO entregadores (nome, numero_telefone, cpf, rg, cep, email) VALUES('{nome}', '{numero_tel}', '{cpf}', '{rg}', '{cep}', '{email}')";
            db.ExecutarComando(inserir);
        }



        public void AlterarEntregadores()
        {
            string alterar = $"UPDATE entregadores SET nome = '{nome}', numero_telefone = '{numero_tel}', cpf = '{cpf}', rg = '{rg}', cep = '{cep}', email = '{email}' WHERE id = '{id}'";
            db.ExecutarComando(alterar);
        }

        public void ExcluirEntregadores()
        {
            string excluir = $"DELETE FROM entregadores WHERE id = '{id}'";
            db.ExecutarComando(excluir);
        }


        public DataTable ListarEntregadores()
        {
            string listarTodos = "SELECT * FROM entregadores ORDER BY id;";
            return db.ExecutarConsulta(listarTodos);
        }
    }
}
