using System;
using System.Collections.Generic;
using WebServerSignalR.Objetos.Enumeradores;

namespace WebServerSignalR.Objetos
{
    public class RequisicaoSql
    {
        public long CodigoUsuario { get; set; }
        public string ComandoSql { get; set; }
        public DateTime DataHoraRequisicao { get; set; }
        public long CodigoRequisicao { get; set; }
        public IList<ParametroSql> Parametros { get; set; }
        public TipoConsulta  Tipo { get; set; }

        public RequisicaoSql(long codigoUsuario, string comandoSql, DateTime dataHoraRequisicao, long codigoRequisicao, IList<ParametroSql> parametros, TipoConsulta tipo)
        {
            this.CodigoUsuario = codigoUsuario;
            this.ComandoSql = comandoSql;
            this.DataHoraRequisicao = dataHoraRequisicao;
            this.CodigoRequisicao = codigoRequisicao;
            this.Parametros = parametros;
            this.Tipo = tipo;
        }
    }
}