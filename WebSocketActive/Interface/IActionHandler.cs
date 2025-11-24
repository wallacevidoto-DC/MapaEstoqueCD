using System.Net.WebSockets;
using System.Text.Json;

namespace MapaEstoqueCD.WebSocketActive.Interface
{
    public interface IActionHandler
    {
        string ActionName { get; }
        Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket);
    }
    public static class ActionsWs
    {
        public const string GET_ESTOQUE = "get_estoque";
        public const string GET_ESTOQUE_ENTRADA = "get_estoque_entrada";
        public const string GET_ADDRESS = "get_address";
        public const string ENTRADA = "entrada";
        public const string SAIDA = "saida";
        public const string TRANSFERENCIA = "transferencia";
        public const string CORRECAO = "correcao";
        public const string CORRECAO_ENTRADA = "correcao_entrada";
        public const string GET_PRODUTO = "get_produto";
        public const string GET_PRODUTO_EAN = "get_produto_cod";
        public const string LOGIN = "login"; 
        public const string CONFERENCIA_LIVRE = "conferencia_livre";
        public const string REMOVE_CONFERENCIA = "remove_estoque_entrada";
    }

    public class WebSocketResponse
    {
        public string type { get; set; } = "";
        public string status { get; set; } = "";
        public string mensagem { get; set; } = "";
        public object? dados { get; set; } = null;
    }

}

