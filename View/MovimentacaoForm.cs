using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Utils;

namespace MapaEstoqueCD.View
{
    public partial class MovimentacaoForm : Form
    {
        private readonly MovimetacaoController movimetacaoController = new();
        public MovimentacaoForm()
        {
            InitializeComponent();

            //Grids.SetDefaultListViews(movimetacaoController.Columns, ref listView1);
            movimetacaoController.GetAllMovimentacao(ref dataGridView1);
        }
    }
}
