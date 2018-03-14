using ClientConsoleSignalR.ADO;
using Microsoft.AspNet.SignalR.Client;
using System;

namespace ClientConsoleSignalR
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = null;
            string json = null;

            var hubConnection = new HubConnection("http://localhost:54132/");
            IHubProxy serverHub = hubConnection.CreateHubProxy("BroadcastHub");
            serverHub.On<string, string>("obterConsulta", (idCliente, sql) =>
                {
                    if (idCliente == 45.ToString())
                    {
                        json = Conexao.ObterDados(sql);
                        Console.WriteLine($"{DateTime.Now:G} - SQL Recebido: [{sql}]");
                        serverHub.Invoke("devolverDados", json);
                    }
                }
            );

            hubConnection.Start().Wait();

            serverHub.Invoke("Notify", "Console app", hubConnection.ConnectionId);

            
            while ((msg = Console.ReadLine()) != null)
            {
                return;
            }
        }
    }
}
