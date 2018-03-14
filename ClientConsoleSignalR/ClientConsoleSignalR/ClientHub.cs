using Microsoft.AspNet.SignalR;
using System;

namespace ClientConsoleSignalR
{
    public class ClientHub : Hub
    {
        public void RealizarConsulta(int id, string sql)
        {
            this.Clients.All.ExibeResultado(id, sql);

            Console.WriteLine($"Id: {id} Sql: {sql} às {DateTime.Now:F}");
        }
    }
}
