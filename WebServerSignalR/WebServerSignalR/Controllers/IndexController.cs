using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Web.Mvc;
using WebServerSignalR.Objetos;
using WebServerSignalR.Funcoes;
using System.Data;
using Newtonsoft.Json;

namespace WebServerSignalR.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Broadcast(Models.Index dados)
        {
            string retorno = string.Empty;
            var hub  = GlobalHost.ConnectionManager.GetHubContext<Hubs.BroadcastHub>();
            var hubConnection = new HubConnection("http://localhost:54132/");
            IHubProxy serverHub = hubConnection.CreateHubProxy("BroadcastHub");
            DateTime startBroadcast = DateTime.Now;
            RespostaRequisicaoSql resposta;

            try
            {
                resposta = new RespostaRequisicaoSql();

                //Cria o objeto da requisicao
                RequisicaoSql requisicao = Requisicoes.CriarRequisicaoSql(dados.Codigo, dados.Consulta);

                //Serializa a requisicao em JSon para broadcast
                //string requisicaoJSON = Requisicoes.SerializaRequisicaoSql(requisicao);

                //Dispara o broadcast para os clients console
                hub.Clients.All.obterConsulta(requisicao);

                //Fica escutando o evento de retorno que será disparado pelos consoles
                serverHub.On<RespostaRequisicaoSql>("exibeResultado", (resp) =>
                {
                    resposta = resp;
                }
                );

                hubConnection.Start().Wait();

                serverHub.Invoke("Notify", "Controller Call", hubConnection.ConnectionId);

                while (resposta.CodigoRequisicaoSql <= 0)
                {
                    if ((DateTime.Now - startBroadcast).TotalSeconds >= 15)
                    {
                        resposta.MensagemErro = "Time Out";
                        break;
                    }
                }

                //resposta = Requisicoes.DeserializaRespostaRequisicaoSql(retorno);
                resposta.Retorno[0] = JsonConvert.DeserializeObject<DataTable>(resposta.Retorno[0].ToString());

                return View(resposta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                hubConnection.Dispose();
            }
        }
    }
}