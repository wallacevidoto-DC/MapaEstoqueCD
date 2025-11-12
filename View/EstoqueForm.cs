using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.Utils.Print;
using MapaEstoqueCD.View.Modal;

namespace MapaEstoqueCD.View
{
    public partial class EstoqueForm : Form
    {
        private readonly EstoqueController estoqueController = new();
        private List<FiltroItem> filtrosAtivos = new();
        private List<EstoqueWsDto> produtosCurrent;
        private ToolTip tooltipSoma = new ToolTip();
        private EstoqueWsDto produtoSelecionado;

        public EstoqueForm()
        {
            InitializeComponent();

            //estoqueController.GetAllEstoque(ref dataGridView1);
            produtosCurrent = estoqueController.GetAllEstoque(ref dataGridView1);

            tooltipSoma.IsBalloon = true;
            tooltipSoma.BackColor = Color.LightYellow;
            tooltipSoma.ForeColor = Color.Black;
            tooltipSoma.ToolTipTitle = "Soma das Quantidades";

            if (!ControlAccess.IsSupers())
            {
                toolStripButton_importar.Visible = false;
                toolStripButton_exportar.Visible = false;
                toolStripButton_entrada.Visible = false;
                toolStripSeparator4.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator2.Visible = false;
            }
        }

        private void toolStripButton_filtrar_Click(object sender, EventArgs e)
        {

            var filtrosSelecionados = FiltroAvancado.ShowDialogAndReturn(estoqueController.Columns, filtrosAtivos);
            filtrosAtivos = filtrosSelecionados;
            produtosCurrent = estoqueController.GetEstoquetByFilter(filtrosAtivos, ref dataGridView1);


        }

        private async void toolStripButton_importar_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<Produtos> sd = estoqueController.GetAllProduct();
                await ExcelImporter.ImportarEstoque(ofd.FileName, sd);
                estoqueController.GetAllEstoque(ref dataGridView1);
                MessageBox.Show("Importação concluída com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton_entrada_Click(object sender, EventArgs e)
        {
            (new EntradaProduto()).ShowDialog();
            produtosCurrent = produtosCurrent = estoqueController.GetAllEstoque(ref dataGridView1);
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string nomeColunaQtd = "Column7";
            var colunaQtd = dataGridView1.Columns[nomeColunaQtd];
            if (colunaQtd == null) return;

            var celulasQtd = dataGridView1.SelectedCells
                .Cast<DataGridViewCell>()
                .Where(c => c.OwningColumn == colunaQtd && c.Value != null)
                .ToList();

            if (celulasQtd.Count > 1)
            {
                double soma = 0;
                foreach (var cell in celulasQtd)
                {
                    if (double.TryParse(cell.Value.ToString(), out double valor))
                        soma += valor;
                }
                Rectangle headerRect = dataGridView1.GetCellDisplayRectangle(colunaQtd.Index, -1, true);

                Point posNaTela = dataGridView1.PointToScreen(
                    new Point(headerRect.X + headerRect.Width / 2, headerRect.Bottom));
                Point posNoPainel = dataGridView1.Parent.PointToClient(posNaTela);

                tooltipSoma.Show($"Total: {soma}", dataGridView1.Parent, posNoPainel, 5000);
            }
            else
            {
                tooltipSoma.Hide(dataGridView1.Parent);
            }
        }

        private void saídaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (produtoSelecionado is not null)
            {
                (new SaidaProduto(produtoSelecionado)).ShowDialog();
                produtosCurrent = estoqueController.GetAllEstoque(ref dataGridView1);
                produtoSelecionado = null;
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var hit = dataGridView1.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                int rowIndex = hit.RowIndex;

                dataGridView1.ClearSelection();
                dataGridView1.Rows[rowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[Math.Max(0, hit.ColumnIndex)];

                string valorPrimeiraCelula = dataGridView1.Rows[rowIndex].Cells[0].Value?.ToString() ?? string.Empty;

                produtoSelecionado = produtosCurrent.FirstOrDefault(p => p.estoqueId.ToString() == valorPrimeiraCelula);
            }

        }

        private void cORREÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (produtoSelecionado is not null)
            {
                (new CorrecaoProduto(produtoSelecionado)).ShowDialog();
                produtosCurrent = estoqueController.GetAllEstoque(ref dataGridView1);
                produtoSelecionado = null;
            }
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estoqueController.PrintPdf(produtosCurrent);

            //string path = @"D:\Downloads\estoque_exportado.pdf";
            //string directory = Path.GetDirectoryName(path)!;
            //Directory.CreateDirectory(directory); // Cria se não existir

            //ExportDataGridViewToPdf.ExportDataGridViewStyled(dataGridView1, path);
        }

        private void eXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estoqueController.PrintExcel(produtosCurrent);
        }

        private void tRANSFERÊNCIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new TransferenciaProduto(produtoSelecionado)).ShowDialog();
            produtosCurrent = estoqueController.GetAllEstoque(ref dataGridView1);
            produtoSelecionado = null;
        }
    }
}
