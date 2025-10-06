using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Models;
using Server.Service;
using System;

namespace MapaEstoqueCD.Controller
{
    public class CacheMP
    {
        private static readonly Lazy<CacheMP> _instance = new Lazy<CacheMP>(() => new CacheMP());
        public static CacheMP Instance => _instance.Value;

        public AppDbContext Db { get; private set; }

        private readonly ServerService server = new();
        public User UserCurrent = null;

        #region Events
        public event Action<List<string>>? OnLogServerChanged;

        private Action<List<string>>? _serverLogHandler;

        #endregion

        private CacheMP()
        {
            Db = new AppDbContext();
            InitServerAsync().GetAwaiter().GetResult();
        }

        #region Server       
        public async Task InitServerAsync()
        {
            _serverLogHandler = (logs) =>
            {
                OnLogServerChanged?.Invoke(logs);
            };

            server.OnLogServerChanged += _serverLogHandler;

            await server.StartAsync();
        }

        public void StopedServerAsync()
        {
            server.Stop();


            if (_serverLogHandler != null)
                server.OnLogServerChanged -= _serverLogHandler;
        }

        public async Task RestartServerAsync()
        {

            if (_serverLogHandler != null)
                server.OnLogServerChanged -= _serverLogHandler;

            await server.RestartAsync();


            if (_serverLogHandler != null)
                server.OnLogServerChanged += _serverLogHandler;
        }

        public List<string> GetServerLogs()
        {
            return server.LogServer;
        }
        #endregion
    }

}
