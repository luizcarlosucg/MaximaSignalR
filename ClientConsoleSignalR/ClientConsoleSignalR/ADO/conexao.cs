using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClientConsoleSignalR.Objetos;

namespace ClientConsoleSignalR.ADO
{
    public class Conexao
    {
        public static DataTable ObterDados(string sql, IList<ParametroSql> parametros)
        {
            string stringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=MaximaSignalR;Integrated Security=SSPI";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexao))
                {
                    SqlDataReader dr = null;

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;

                        foreach (var parametro in parametros)
                        {
                            cmd.Parameters.AddWithValue(parametro.Nome, parametro.Valor);
                        }

                        conn.Open();
                        dr = cmd.ExecuteReader();
                        
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        return dt;
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
