using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ClientConsoleSignalR.ADO
{
    public class Conexao
    {
        public static string ObterDados(string sql)
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=MaximaSignalR;Integrated Security=SSPI");

            SqlDataReader dr = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                return JsonConvert.SerializeObject(dt, Formatting.Indented);
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
