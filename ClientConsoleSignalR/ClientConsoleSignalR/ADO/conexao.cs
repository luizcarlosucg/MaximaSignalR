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
        public static RespostaRequisicaoSql ObterDados(string sql, IList<ParametroSql> parametros)
        {
            RespostaRequisicaoSql retorno = new RespostaRequisicaoSql();

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

                        retorno.OcorreuErro = false;
                        retorno.LinhasAfetadas = dr.RecordsAffected;
                        retorno.Retorno.Add(dt);
                    }
                }
            }
            catch(Exception ex)
            {
                retorno.OcorreuErro = true;
                retorno.LinhasAfetadas = 0;
                retorno.MensagemErro = ex.Message;
            }

            return retorno;
        }
    }
}
