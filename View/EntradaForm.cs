using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.View.Modal;

namespace MapaEstoqueCD.View
{
    public partial class EntradaForm : Form
    {
        private List<FiltroItem> filtrosAtivos = new();
        private readonly EntradasControllers entradasControllers = new();
        private List<EntradasViewerDto> entradasCurrent;
        private EntradasViewerDto entradaSelecionado;
        public EntradaForm()
        {
            InitializeComponent();

            entradasCurrent = entradasControllers.AllGetEntradas(ref dataGridView1);
        }


        private void toolStripButton_filtrar_Click(object sender, EventArgs e)
        {
            var filtrosSelecionados = FiltroAvancado.ShowDialogAndReturn(entradasControllers.Columns, filtrosAtivos);
            filtrosAtivos = filtrosSelecionados;
            entradasCurrent = entradasControllers.GetEntradasByFilter(filtrosAtivos, ref dataGridView1);
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entradasControllers.PrinfPdf(entradasCurrent);
        }

        private void eXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entradasControllers.PritExcel(entradasCurrent);
        }

        private void entrdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entradaSelecionado is not null)
            {
                var tt = (new EntradaProduto(entradaSelecionado)).ShowDialog();
                if (tt == DialogResult.OK)
                {
                    entradasControllers.SetEntradaLivreConferida(entradaSelecionado);
                    entradaSelecionado = null;
                    entradasCurrent = entradasControllers.GetEntradasByFilter(filtrosAtivos, ref dataGridView1);

                }
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

                entradaSelecionado = entradasCurrent.FirstOrDefault(p => p.EntradaId.ToString() == valorPrimeiraCelula);
            }
        }
    }
}