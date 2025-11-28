using MapaEstoqueCD.Controller;
using MapaEstoqueCD.WebSocketActive.Interface;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace MapaEstoqueCD.WebSocketActive
{
    public class WebSocketService
    {
        private static readonly Lazy<WebSocketService> _instance = new Lazy<WebSocketService>(() => new WebSocketService());
        public static WebSocketService Instance => _instance.Value;

        private readonly ActionDispatcher _dispatcher;

        public WebSocketService()
        {
            _dispatcher = new ActionDispatcher(new IActionHandler[]
               {
                    new GetEstoqueHandler(),
                    new GetEstoqueEntradaHandler(),
                    new LoginHandler(),
                    new EntradaHandler(),
                    new PickingHandler(),
                    new EntradaConferenciaHandler(),
                    new EnderecoHandler(),
                    new ProdutoHandler(),
                    new SaidaHandler(),
                    new TransferenciaHandler(),
                    new CorrecaoHandler(),
                    new CorrecaoEntradaHandler(),
                    new ProdutoEanHandler(),
                    new EnderecoConferenciaLivreHandler(),
                     new RemoveConferenciaHandler()
               });
        }

        public void ConnectEvents()
        {
            CacheMP.Instance.DataRecevied += Instance_DataRecevied;
        }

        private async void Instance_DataRecevied((string, JsonElement, WebSocket) obj)
        {
            WebSocketResponse result = await _dispatcher.DispatchAsync(obj.Item1, obj.Item2, obj.Item3);


            CacheMP.Instance.server.SendMsgWs(obj.Item3, result);

        }

        private async Task SendResponseAsync(WebSocket socket, string type, string status, string mensagem = "",  object? dados = null)
        {
            var response = new WebSocketResponse
            {
                type = type,
                status = status,
                mensagem = mensagem,
                dados = dados
            };

            string json = JsonSerializer.Serialize(response);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            await socket.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
        }

    }
}
