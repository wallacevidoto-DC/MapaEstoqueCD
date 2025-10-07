using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaEstoqueCD.Utils
{
    public static class ProgressHelper
    {
        public static async Task RunWithProgressAsync(int maxProgress, Func<IProgress<int>, Task> action)
        {
            var statusStrip = MainWindow.Instance.statusStrip1; 

            if (statusStrip == null)
                throw new InvalidOperationException("StatusStrip não encontrado na MainWindow.");

            // Cria a ProgressBar
            var progressBar = new ToolStripProgressBar
            {
                Minimum = 0,
                Maximum = maxProgress,
                Value = 0,
                Size = new System.Drawing.Size(200, 16)
            };

            statusStrip.Items.Add(progressBar);
            statusStrip.Refresh();

            // IProgress para atualizar a progress bar
            var progress = new Progress<int>(value =>
            {
                progressBar.Value = Math.Min(value, progressBar.Maximum);
            });

            try
            {
                // Executa a ação passada
                await action(progress);
            }
            finally
            {
                // Remove a progress bar ao finalizar
                statusStrip.Items.Remove(progressBar);
                statusStrip.Refresh();
            }
        }
    }
}

