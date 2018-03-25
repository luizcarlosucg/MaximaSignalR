using System;
using System.Collections.Generic;
using ClientConsoleSignalR.Objetos.Enumeradores;

namespace ClientConsoleSignalR.Objetos
{
    public class RequisicaoSql
    {
        public long CodigoUsuario { get; set; }
        public string ComandoSql { get; set; }
        public DateTime DataHoraRequisicao { get; set; }
        public long CodigoRequisicao { get; set; }
        public IList<ParametroSql> Parametros { get; set; }
        public TipoConsulta Tipo { get; set; }
    }
}
