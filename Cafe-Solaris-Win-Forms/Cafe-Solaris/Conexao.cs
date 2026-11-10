using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafe_Solaris
{
    internal class Conexao
    {
        MySqlConnection conn;

        //Método para estabelecer a conexão com o banco de dados MySQL
        private void Conectar()
        {
            try
            {
                string dadosConexao = "Persist Security Info=False;Server=127.0.0.1;Port=3306;Database=cafe_solaris;Uid=root;Pwd=;";
                conn = new MySqlConnection(dadosConexao);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Conexão NÃO estabelecida. \n{ex.Message}");
            }
        }

        //Um método público capaz de executar qualquer instrução INSERT, UPDATE E DELETE
        public void ExecutarComando(string sql) //sql é uma instrução de insert, ou update ou delete.
        {
            Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro ao tentar executar {sql}\n{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        //Método para executar SELECT.
        public DataTable ExecutarConsulta(string query) //variável query vai arrumar uma instrução SELECT para ser executada
        {
            Conectar();
            try
            {
                MySqlDataAdapter dados = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dados.Fill(dt);             //o resultado do select será utilizado para preencher (Fill) o datatable
                return dt;
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Erro na instrução SELECT. \n{query}\n{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        //NOVO: executa vários comandos parametrizados dentro de uma transação.
        //Obs.: as tabelas estão em MyISAM, que não desfaz (rollback) alterações.
        //Para ter rollback de verdade, converta as tabelas para InnoDB.
        public void ExecutarEmTransacao(Action<MySqlConnection, MySqlTransaction> acao)
        {
            Conectar();
            MySqlTransaction transacao = null;
            try
            {
                transacao = conn.BeginTransaction();
                acao(conn, transacao);
                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao?.Rollback();
                throw new Exception($"Erro ao gravar no banco.\n{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
