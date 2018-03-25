using System.Collections.Generic;
using System.Data;

namespace ClientConsoleSignalR.Objetos
{
    public class RespostaRequisicaoSql
    {
        public long CodigoRequisicaoSql { get; set; }
        public IList<dynamic> Retorno { get; set; }
        public bool OcorreuErro { get; set; }
        public string MensagemErro { get; set; }
        public int LinhasAfetadas { get; set; }
        public IList<ParametroEntrada> Parametros { get; set; }

        public RespostaRequisicaoSql()
        {
            this.Retorno = new List<dynamic>();
        }

        public RespostaRequisicaoSql(long codigoRequisicaoSql, IList<dynamic> retorno, bool ocorreuErro, string mensagemErro, int linhasAfetadas, IList<ParametroEntrada> parametros)
        {
            this.CodigoRequisicaoSql = codigoRequisicaoSql;
            this.Retorno = retorno;
            this.OcorreuErro = ocorreuErro;
            this.MensagemErro = mensagemErro;
            this.LinhasAfetadas = LinhasAfetadas;
            this.Parametros = parametros;
        }
    }
}
