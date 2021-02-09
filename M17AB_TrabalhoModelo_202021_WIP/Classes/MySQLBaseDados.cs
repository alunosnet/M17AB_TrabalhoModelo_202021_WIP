using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace M17AB_TrabalhoModelo_1920.Classes
{
    public class MySQLBaseDados
    {
        private string strLigacao;
        private MySqlConnection ligacaoBD;
        public MySQLBaseDados()
        {
            //ligação à bd
            strLigacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            ligacaoBD = new MySqlConnection(strLigacao);
            ligacaoBD.Open();
        }
        ~MySQLBaseDados()
        {
            try
            {
                ligacaoBD.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #region Transações
        public MySqlTransaction iniciarTransacao()
        {
            return ligacaoBD.BeginTransaction();
        }
        public MySqlTransaction iniciarTransacao(IsolationLevel isolamento)
        {
            return ligacaoBD.BeginTransaction(isolamento);
        }
        #endregion
        #region SQL de ação
        public void executaSQL(string sql)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando = null;
        }

        public void executaSQL(string sql, List<SqlParameter> parametros)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando = null;
        }
        public void executaSQL(string sql, List<SqlParameter> parametros, MySqlTransaction transacao)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            comando.Transaction = transacao;
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando = null;
        }
        public int executaEDevolveSQL(string sql)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            int id = (int)comando.ExecuteScalar();
            comando.Dispose();
            comando = null;
            return id;
        }
        public int executaEDevolveSQL(string sql, List<SqlParameter> parametros)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            int id = (int)comando.ExecuteScalar();
            comando.Dispose();
            comando = null;
            return id;
        }
        public int executaEDevolveSQL(string sql, List<SqlParameter> parametros, MySqlTransaction transacao)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            comando.Transaction = transacao;
            int id = (int)comando.ExecuteScalar();
            comando.Dispose();
            comando = null;
            return id;
        }
        #endregion
        #region SQL Consultas
        /// <summary>
        /// Devolve o resultado de uma consulta
        /// </summary>
        /// <param name="sql">Select à base de dados</param>
        /// <returns></returns>
        public DataTable devolveSQL(string sql)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();
            MySqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            dados = null;
            comando.Dispose();
            comando = null;
            return registos;
        }
        ///
        public DataTable devolveSQL(string sql, List<SqlParameter> parametros)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();
            comando.Parameters.AddRange(parametros.ToArray());
            MySqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            dados = null;
            comando.Dispose();
            comando = null;
            return registos;
        }
        public DataTable devolveSQL(string sql, List<SqlParameter> parametros, MySqlTransaction transacao)
        {
            MySqlCommand comando = new MySqlCommand(sql, ligacaoBD);
            comando.Transaction = transacao;
            DataTable registos = new DataTable();
            comando.Parameters.AddRange(parametros.ToArray());
            MySqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            dados = null;
            comando.Dispose();
            comando = null;
            return registos;
        }
        #endregion
    }
}