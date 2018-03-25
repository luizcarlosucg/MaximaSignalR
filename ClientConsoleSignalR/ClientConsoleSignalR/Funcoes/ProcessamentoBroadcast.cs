using Newtonsoft.Json;
using ClientConsoleSignalR.Objetos;
using System.Collections.Generic;

namespace ClientConsoleSignalR.Funcoes
{
    public static class ProcessamentoBroadcast
    {
        public static RequisicaoSql DeserializaRequisicaoSql(string requisicaoJSON)
        {
            RequisicaoSql requisicao;

            requisicao = JsonConvert.DeserializeObject<RequisicaoSql>(requisicaoJSON);

            return requisicao;
        }

        public static string SerializaRespostaRequisicaoSql(RespostaRequisicaoSql resposta)
        {
            return JsonConvert.SerializeObject(resposta, Formatting.Indented);
        }

        public static IList<ParametroEntrada> CriarParametros()
        {
            IList<ParametroEntrada> parametros = new List<ParametroEntrada>();
            parametros.Add(new ParametroEntrada("nome 1", 10));
            parametros.Add(new ParametroEntrada("nome 2", 20));
            return parametros;
        }
    }
}
