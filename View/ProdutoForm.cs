using MapaEstoqueCD.View.Modal;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.Controller;

namespace MapaEstoqueCD.View
{
    public partial class ProdutoForm : Form
    {
        private readonly ProdutosController produtosController = new();
        private List<FiltroItem> filtrosAtivos = new();
        public ProdutoForm()
        {
            InitializeComponent();
            Grids.SetDefaultListViews(produtosController.Columns, ref listView1);
            produtosController.GetAllProduct(ref listView1);
        }




        private void btnFiltroAvancado_Click(object sender, EventArgs e)
        {

            using var filtro = new FiltroAvancadoForm(produtosController.Columns, filtrosAtivos);
            filtrosAtivos = filtro.Resultado;


            if (filtro.ShowDialog() == DialogResult.OK)
            {
                filtrosAtivos = filtro.Resultado;
                var filtros = filtro.Resultado;

                produtosController.GetProductByFilter(filtros, ref listView1);
            }
        }
    }
}
