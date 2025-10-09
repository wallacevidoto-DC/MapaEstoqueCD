using MapaEstoqueCD.WebSocketActive.Interface;
using System.Net.WebSockets;
using System.Text.Json;

namespace MapaEstoqueCD.WebSocketActive
{
    public class ActionDispatcher
    {
        private readonly Dictionary<string, IActionHandler> _handlers = new(StringComparer.OrdinalIgnoreCase);

        public ActionDispatcher(IEnumerable<IActionHandler> handlers)
        {
            foreach (var handler in handlers)
            {
                _handlers[handler.ActionName] = handler;
            }
        }

        public async Task<WebSocketResponse?> DispatchAsync(string action, JsonElement data, WebSocket socket)
        {
            if (!_handlers.TryGetValue(action, out var handler))
                return null;
                //throw new InvalidOperationException($"Ação desconhecida: {action}");

            return await handler.ExecuteAsync(data, socket);
        }
    }

}
