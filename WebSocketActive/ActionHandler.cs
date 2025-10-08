using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.WebSocketActive.Interface;
using System.Net.WebSockets;
using System.Text.Json;

namespace MapaEstoqueCD.WebSocketActive
{
    public class GetEstoqueHandler : IActionHandler
    {
        public readonly EstoqueService estoqueService = new();
        public string ActionName => ActionsWs.GET_ESTOQUE;

        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                List<Estoque> estoque = estoqueService.GetAll();

                return new WebSocketResponse { type = "estoque", status = "ok", mensagem = "es",dados=estoque };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse { type = $"{ActionsWs.GET_ESTOQUE}_resposta", status = "erro", mensagem = ex.Message };
            }

            // Simulação de busca no estoque
            await Task.Delay(50);
            return null;// new { status = "ok", estoque = 123 };
        }
    }

    public class LoginHandler : IActionHandler
    {
        public readonly UserService userService = new();
        public string ActionName => ActionsWs.LOGIN;

        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                var user = userService.Login(data.GetProperty("username").GetString(), data.GetProperty("password").GetString());

                if (user != null)
                {
                    return new WebSocketResponse { type = "login_resposta", status = "ok", mensagem = "Login realizado com sucesso",dados= user.Role };
                }
                return new WebSocketResponse { type = "login_resposta", status = "erro", mensagem = "Algum dado errado" };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse { type = "login_resposta", status = "erro", mensagem = ex.Message };
            }
           
        }
    }

}
