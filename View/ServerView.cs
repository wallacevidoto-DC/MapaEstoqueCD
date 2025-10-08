using MapaEstoqueCD.Controller;
using Microsoft.VisualBasic.Logging;
using Server.Models;
using Server.Service;

namespace MapaEstoqueCD.View
{
    public partial class ServerView : Form
    {

        private readonly Dictionary<LogType, Color> logColors = new()
        {
            { LogType.INFO, Color.LightGray },
            { LogType.ERRO, Color.Red },
            { LogType.SUCESSO, Color.LimeGreen },
            { LogType.ENVIADO, Color.Cyan },
            { LogType.RECEBIDO, Color.Orange },
            { LogType.ATIVO, Color.Lime },
            { LogType.INATIVO, Color.Gray },
            { LogType.CONECTADO, Color.LightGreen },
            { LogType.DESCONECTADO, Color.OrangeRed }

        };

        public ServerView()
        {
            InitializeComponent();


            InitializeLog(CacheMP.Instance.GetServerLogs());
            CacheMP.Instance._serverLogHandler += OnServerLog;
        }

        private void InitializeLog(List<LogModel> logModels)
        {
            for (int i = 0; i < logModels.Count; i++)
            {
                AddLog(logModels[i]);
            }
        }

        private void OnServerLog(LogModel model)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddLog(model)));
            }
            else
            {
                AddLog(model);
            }

        }



        private void AddLog(LogModel log)
        {
            listBoxLogs.Items.Add(log);
            listBoxLogs.TopIndex = listBoxLogs.Items.Count - 1; // rolagem automática
        }

        private void listBoxLogs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var log = (LogModel)listBoxLogs.Items[e.Index];
            Color color = logColors.ContainsKey(log.Type) ? logColors[log.Type] : Color.White;

            e.Graphics.FillRectangle(new SolidBrush(listBoxLogs.BackColor), e.Bounds); // fundo escuro da linha

            using (SolidBrush brush = new SolidBrush(color))
            {
                // Adiciona um padding à esquerda e topo
                RectangleF rect = new RectangleF(e.Bounds.X + 4, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height);
                //string text = $"[{log.Date:HH:mm:ss}] [{log.Service}] [{log.Type}] {log.Message}";

                string time = $"[{log.Date.ToString("dd/MM/yyyy HH:mm:ss")}]".PadRight(25);
                string service = $"[{log.Service}]".PadRight(20);
                string type = $"[{log.Type.ToString()}]".PadRight(15);
                string message = log.Message;

                //string text = $"[{time}] [{service}] [{type}] {message}";
                string text = $"{time}{service}{type}{message}";
                e.Graphics.DrawString(text, e.Font, brush, rect);
            }

            e.DrawFocusRectangle();
        }
    }
}