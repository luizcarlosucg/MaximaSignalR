using Microsoft.AspNet.SignalR;

namespace WebServerSignalR.Hubs
{
    public class BroadcastHub : Hub
    {
        public void ConsultarDados(string id, string sql)
        {
            this.Clients.All.ObterConsulta(id, sql);
        }

        public void DevolverDados(string dados)
        {
            this.Clients.All.ExibeResultado(dados);
        }

    }
}