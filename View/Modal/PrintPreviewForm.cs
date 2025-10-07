using MapaEstoqueCD.Utils.Print;
using System.Diagnostics;
using System.Drawing.Printing;

namespace MapaEstoqueCD.View.Modal
{
    public partial class PrintPreviewForm : Form
    {
        private readonly ePrintDocument printDocument;
        private TrackBar trackBar_zoom = new TrackBar();

        public PrintPreviewForm(ePrintDocument printDocument)
        {
            InitializeComponent();
            this.printDocument = printDocument;
            printPreviewControl_preview.Document = printDocument;
            printPreviewControl_preview.Zoom = 1f;
            printPreviewControl_preview.UseAntiAlias = true;
            printPreviewControl_preview.AutoZoom = true;

            printDocument.PagesCount += PrintDocument_PagesCount;

            ConfigurarZoom();
        }

        private void PrintDocument_PagesCount(object? sender, CountPagesEventArgs e)
        {
            //printPreviewControl_preview.Rows = printDocument.totalPages;

            int columns = (int)Math.Ceiling(Math.Sqrt(printDocument.totalPages)); // Aproxima pela raiz quadrada
            int rows = (int)Math.Ceiling((double)printDocument.totalPages / columns); // Distribui nas linhas

            printPreviewControl_preview.Rows = rows;
            printPreviewControl_preview.Columns = columns;
        }

        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Salvar como PDF",
                FileName = printDocument.DocumentName
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    printDocument.PrinterSettings.PrintFileName = saveDialog.FileName;
                    printDocument.PrinterSettings.PrintToFile = true;

                    // Define um PrintController para capturar corretamente as páginas
                    printDocument.PrintController = new StandardPrintController();
                    printDocument.Print();

                    Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDocument.PrinterSettings.IsValid)
                {
                    printDocument.Print();
                    MessageBox.Show("Impressão enviada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro: Impressora não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao imprimir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (printDocument != null)
            {
                printDocument.Dispose();
            }
        }

        private void ConfigurarZoom()
        {
            trackBar_zoom.Minimum = 1;  // 10% de zoom
            trackBar_zoom.Maximum = 20; // 200% de zoom
            trackBar_zoom.Value = 10;   // Começa com 100%
            trackBar_zoom.TickFrequency = 1;
            trackBar_zoom.Dock = DockStyle.Bottom;

            trackBar_zoom.Scroll += (s, e) =>
            {
                printPreviewControl_preview.Zoom = trackBar_zoom.Value / 10.0; // Converte para 0.1 - 2.0
            };

            this.Controls.Add(trackBar_zoom);
        }

        private void printPreviewControl_preview_Click(object sender, EventArgs e)
        {

        }
    }
}
