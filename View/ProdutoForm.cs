using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;

namespace MapaEstoqueCD.View
{
    public partial class ProdutoForm : Form
    {
        private readonly ProdutosController produtosController = new();
        private List<FiltroItem> filtrosAtivos = new();
        private List<Produtos> produtosCurrent;
        public ProdutoForm()
        {
            InitializeComponent();
            Grids.SetDefaultDataGridView(ref dataGridView1);
            produtosCurrent = produtosController.GetAllProduct(ref dataGridView1);

            if (!ControlAccess.IsSupers())
            {
                toolStripButton_importar.Visible = false;
                toolStripButton_exportar.Visible = false;
                toolStripButton_cadastrar.Visible = false;
                toolStripSeparator4.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator2.Visible = false;
            }
        }




        private void btnFiltroAvancado_Click(object sender, EventArgs e)
        {
            var filtrosSelecionados = FiltroAvancado.ShowDialogAndReturn(produtosController.Columns, filtrosAtivos);
            filtrosAtivos = filtrosSelecionados;
            produtosCurrent = produtosController.GetProductByFilter(filtrosAtivos, ref dataGridView1);
        }

        private void toolStripButton_cadastrar_Click(object sender, EventArgs e)
        {
            (new ProdutoEdit()).ShowDialog();
            ReloadGrid();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string valorPrimeiraCelula = row.Cells[0].Value?.ToString() ?? string.Empty;

                (new ProdutoEdit(produtosController.GetByCod(valorPrimeiraCelula))).ShowDialog();
                ReloadGrid();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada!");
            }
        }

        private void toolStripButton_importar_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter.ImportarProdutos(ofd.FileName);
                produtosController.GetAllProduct(ref dataGridView1);
                MessageBox.Show("Importação concluída com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton_exportar_Click(object sender, EventArgs e)
        {

        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            produtosController.PrintPdf(produtosCurrent);

        }

        private void eXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            produtosController.ExportExcel(produtosCurrent);
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
            }
        }

        private void ReloadGrid()
        {
            produtosCurrent = produtosController.GetAllProduct(ref dataGridView1);
        }
    }
}
