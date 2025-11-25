using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;

namespace MapaEstoqueCD.View.Modal
{
    public partial class HistoricoMovForm : Form
    {
        private readonly MovimentacaoController movimentacaoController = new();
        private List<MovimentacaoDto> movimentacoesCurrent;
        public HistoricoMovForm(MovimentacaoDto movimentacaoDto)
        {
            InitializeComponent();


            movimentacoesCurrent = movimentacaoController.GetMovimeById(ref dataGridView1, movimentacaoDto);
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listaParaPdf = movimentacoesCurrent.ToList();

            var colunaOrdenada = dataGridView1.SortedColumn;
            var direcao = dataGridView1.SortOrder;

            if (colunaOrdenada != null && direcao != SortOrder.None)
            {
                if (movimentacaoController.ColunaParaFunc.TryGetValue(colunaOrdenada.HeaderText, out var func))
                {
                    listaParaPdf = direcao == SortOrder.Ascending
                        ? listaParaPdf.OrderBy(func).ToList()
                        : listaParaPdf.OrderByDescending(func).ToList();
                }
            }
            movimentacaoController.PrintPdf(listaParaPdf);
        }

        private void eXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movimentacaoController.PrintExcel(movimentacoesCurrent);
        }
    }
}

