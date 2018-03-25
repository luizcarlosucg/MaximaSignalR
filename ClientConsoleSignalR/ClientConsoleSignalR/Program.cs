using ClientConsoleSignalR.ADO;
using ClientConsoleSignalR.Funcoes;
using ClientConsoleSignalR.Objetos;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClientConsoleSignalR
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = null;
            DataTable dados;

            var hubConnection = new HubConnection("http://localhost:54132/");
            IHubProxy serverHub = hubConnection.CreateHubProxy("BroadcastHub");
            serverHub.On<RequisicaoSql>("obterConsulta", (requisicao) =>
                {
                    //RequisicaoSql requisicao = ProcessamentoBroadcast.DeserializaRequisicaoSql(requisicaoJSON);
                    if (requisicao.CodigoUsuario == 45)
                    {
                        Console.WriteLine($"Horário disparo: {requisicao.DataHoraRequisicao}");
                        Console.WriteLine($"Horário recebimento: {DateTime.Now:G}");
                        Console.WriteLine($"SQL Recebido: {requisicao.ComandoSql}");
                        Console.WriteLine($"Código Requisição: {requisicao.CodigoRequisicao}");
                        Console.WriteLine($"Tipo Consulta: {requisicao.Tipo}");
                        Console.WriteLine($"Parametros:");
                        foreach (var parametro in requisicao.Parametros)
                        {
                            Console.WriteLine($"    Nome: {parametro.Nome}, Valor: {parametro.Valor}, Tipo: {parametro.Tipo}");
                        }

                        dados = Conexao.ObterDados(requisicao.ComandoSql, requisicao.Parametros);
                        var lista = new List<dynamic>();
                        lista.Add(dados);

                        RespostaRequisicaoSql resposta = new RespostaRequisicaoSql(requisicao.CodigoRequisicao, lista, false, string.Empty, 3, ProcessamentoBroadcast.CriarParametros());

                        serverHub.Invoke("devolverDados", resposta);
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
