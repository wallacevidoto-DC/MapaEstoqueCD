using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;

namespace MapaEstoqueCD.View
{
    public partial class MovimentacaoForm : Form
    {
        private readonly MovimetacaoController movimetacaoController = new();
        private List<FiltroItem> filtrosAtivos = new();
        private List<MovimentacaoDto> movimentacoesCurrent;
        public MovimentacaoForm()
        {
            InitializeComponent();

            //Grids.SetDefaultListViews(movimetacaoController.Columns, ref listView1);
            movimentacoesCurrent = movimetacaoController.GetAllMovimentacao(ref dataGridView1);
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movimetacaoController.PrintPdf(movimentacoesCurrent);
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
    }
}
