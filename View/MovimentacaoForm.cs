using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.View.Modal;
using MapaEstoqueCD.WebSocketActive.Controller;

namespace MapaEstoqueCD.View
{
    public partial class MovimentacaoForm : Form
    {
        private readonly MovimentacaoController movimetacaoController = new();
        private List<FiltroItem> filtrosAtivos = new();
        private List<MovimentacaoDto> movimentacoesCurrent;
        private MovimentacaoDto movimentacaoSelecionado;
        public MovimentacaoForm()
        {
            InitializeComponent();

            //Grids.SetDefaultListViews(movimetacaoController.Columns, ref listView1);
            movimentacoesCurrent = movimetacaoController.GetAllMovimentacao(ref dataGridView1);
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var listaParaPdf = movimentacoesCurrent.ToList();

            var colunaOrdenada = dataGridView1.SortedColumn;
            var direcao = dataGridView1.SortOrder;

            if (colunaOrdenada != null && direcao != SortOrder.None)
            {
                if (movimetacaoController.ColunaParaFunc.TryGetValue(colunaOrdenada.HeaderText, out var func))
                {
                    listaParaPdf = direcao == SortOrder.Ascending
                        ? listaParaPdf.OrderBy(func).ToList()
                        : listaParaPdf.OrderByDescending(func).ToList();
                }
            }
            movimetacaoController.PrintPdf(listaParaPdf);
        }

        private void eXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movimetacaoController.PrintExcel(movimentacoesCurrent);
        }

        private void toolStripButton_filtrar_Click(object sender, EventArgs e)
        {
            var filtrosSelecionados = FiltroAvancado.ShowDialogAndReturn(movimetacaoController.Columns, filtrosAtivos);
            filtrosAtivos = filtrosSelecionados;
            movimentacoesCurrent = movimetacaoController.GetEstoquetByFilter(filtrosAtivos, ref dataGridView1);
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

                movimentacaoSelecionado = movimentacoesCurrent.FirstOrDefault(p => p.movimentacaoId.ToString() == valorPrimeiraCelula);
            }

        }

        private void saídaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (movimentacaoSelecionado is not null && movimentacaoSelecionado.estoqueId is not null)
            {

                (new HistoricoMovForm(movimentacaoSelecionado)).ShowDialog();
            }
        }
    }
}
