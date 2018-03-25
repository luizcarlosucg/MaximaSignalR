using Microsoft.AspNet.SignalR;
using WebServerSignalR.Objetos;

namespace WebServerSignalR.Hubs
{
    public class BroadcastHub : Hub
    {
        public void ConsultarDados(RequisicaoSql requisicaoJSON)
        {
            this.Clients.All.ObterConsulta(requisicaoJSON);
        }

        public void DevolverDados(RespostaRequisicaoSql respostaJSON)
        {
            this.Clients.All.ExibeResultado(respostaJSON);
        }
    }
}