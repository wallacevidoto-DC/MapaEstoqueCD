using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;
using QRCoder;
using Server.Models;

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
            { LogType.ATIVO,    Color.Lime },
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

        private void toolStripButton_qr_Click(object sender, EventArgs e)
        {
            try
            {
                string payload = $"https://{CacheMP.Instance.server.Host}:{CacheMP.Instance.server.HttpPort}/home?ws_ip={CacheMP.Instance.server.Host}&ws_port={CacheMP.Instance.server.WebSocketPort}&app=angular";


                using var qrGenerator = new QRCodeGenerator();

                var qrData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
                using var qrCode = new QRCode(qrData);

                Bitmap qrBitmap = qrCode.GetGraphic(20);


                (new QrViewer(qrBitmap)).ShowDialog();
                // Mostra no PictureBox
                //picQr.Image?.Dispose();
                //picQr.Image = (Bitmap)qrBitmap.Clone(); // clone para evitar conflito de disposal

                //// Habilita salvar e exibe informações básicas
                //btnSave.Enabled = true;
                //lblInfo.Text = $"Conteúdo: {Truncate(payload, 60)}\n\nECC: Q\nTamanho: {picQr.Image.Width}x{picQr.Image.Height} px\nGerado em: {DateTime.Now}";

                // Não descartar o qrBitmap aqui se for usar a imagem (já clonamos para o PictureBox)
                qrBitmap.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar QR code:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton_reload_Click(object sender, EventArgs e)
        {
            CacheMP.Instance.server.RestartAsync();
        }

        private void toolStripButton_certificado_Click(object sender, EventArgs e)
        {
            try
            {
                CacheMP.Instance.server.Stop();

                string batPath = Path.Combine(AppContext.BaseDirectory, "frontend", "start structure.bat");

                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = batPath,
                    WorkingDirectory = Path.GetDirectoryName(batPath),
                    UseShellExecute = true, 
                };

                // Executa o .bat e espera finalizar
                using (var process = System.Diagnostics.Process.Start(processInfo))
                {
                    process.WaitForExit(); // espera terminar
                }

                // Reinicia o server
                CacheMP.Instance.server.StartAsync();
            }
            catch (Exception ex)
            {
                ex.GetErro(ex);
            }
        }
    }
}