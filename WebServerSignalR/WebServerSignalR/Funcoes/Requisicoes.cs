using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using WebServerSignalR.Objetos;

namespace WebServerSignalR.Funcoes
{
    public static class Requisicoes
    {
        public static IList<ParametroSql> CriarParametrosSql()
        {
            IList <ParametroSql> parametros = new List<ParametroSql>();

            parametros.Add(new ParametroSql("Codigo", 2, Objetos.Enumeradores.TipoParametroSql.Inteiro));
            parametros.Add(new ParametroSql("Descricao", "Dados de Teste 2", Objetos.Enumeradores.TipoParametroSql.String));
            parametros.Add(new ParametroSql("Status", true, Objetos.Enumeradores.TipoParametroSql.Booleano));

            return parametros;
        }

        public static RequisicaoSql CriarRequisicaoSql(long codigo, string consulta)
        {
            return new RequisicaoSql(codigo, consulta, DateTime.Now, 1, CriarParametrosSql(), Objetos.Enumeradores.TipoConsulta.Query);
        }

        public static string SerializaRequisicaoSql(RequisicaoSql requisicao)
        {
            return JsonConvert.SerializeObject(requisicao, Formatting.Indented);
        }

        public static RespostaRequisicaoSql DeserializaRespostaRequisicaoSql(string resposta)
        {
            return JsonConvert.DeserializeObject<RespostaRequisicaoSql>(resposta);
        }
    }
}