using System.Collections.Generic;
using System.Data;

namespace WebServerSignalR.Objetos
{
    public class RespostaRequisicaoSql
    {
        public long CodigoRequisicaoSql { get; set; }
        public IList<dynamic> Retorno { get; set; }
        public bool OcorreuErro { get; set; }
        public string MensagemErro { get; set; }
        public int LinhasAfetadas { get; set; }
        public IList<ParametroEntrada> Parametros { get; set; }
    }
}