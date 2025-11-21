using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using Server.Models;
using Server.Service;
using System;
using System.Net.WebSockets;
using System.Text.Json;

namespace MapaEstoqueCD.Controller
{
    public class CacheMP
    {
        private static readonly Lazy<CacheMP> _instance = new Lazy<CacheMP>(() => new CacheMP());
        public static CacheMP Instance => _instance.Value;

        public AppDbContext Db { get; private set; }

        public readonly ServerService server = new();
        public User UserCurrent = null;

        #region Events
        public Action<LogModel>? _serverLogHandler;
        public event Action<(string, JsonElement, WebSocket)> DataRecevied;
        #endregion

        private CacheMP()
        {
            Db = new AppDbContext();
            InitServerAsync().GetAwaiter().GetResult();
            Db.Users.ToList();
            Db.Produtos.ToList();
            Db.Movimentacoes.ToList();
            Db.Estoque.ToList();
            Db.Entradas.ToList();
            Db.Cifs.ToList();




        }

        #region Server       
        public async Task InitServerAsync()
        {           

            server.OnLog += OnlogEventServe;

            await server.StartAsync();

            server.DataRecevied += Server_DataRecevied;

            //var inic = WebSocketService.Instance;
        }

        private void Server_DataRecevied((string, JsonElement, WebSocket) obj)
        {
            DataRecevied?.Invoke(obj);
        }

        private void OnlogEventServe(LogModel model)
        {
            _serverLogHandler?.Invoke(model);
        }

        public void StopedServerAsync()
        {
            server.Stop();


            if (_serverLogHandler != null)
                server.OnLog -= OnlogEventServe;
                server.DataRecevied -= Server_DataRecevied;
        }

        public async Task RestartServerAsync()
        {

            if (_serverLogHandler != null)
                server.OnLog -= OnlogEventServe;

            await server.RestartAsync();
        }

        public List<LogModel> GetServerLogs()
        {
            return server.LogServer;
        }

        #endregion

    }

}
