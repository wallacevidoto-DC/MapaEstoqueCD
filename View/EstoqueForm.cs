using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;

namespace MapaEstoqueCD.View
{
    public partial class EstoqueForm : Form
    {
        //private readonly ProdutosController produtosController = new();
        private readonly EstoqueController estoqueController = new();
        private List<FiltroItem> filtrosAtivos = new();
        private List<EstoqueWsDto> produtosCurrent;
        public EstoqueForm()
        {
            InitializeComponent();

            Grids.SetDefaultListViews(estoqueController.Columns, ref listView1);
            produtosCurrent = estoqueController.GetAllEstoque(ref listView1);

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

            using var filtro = new FiltroAvancadoForm(estoqueController.Columns, filtrosAtivos);

            if (filtro.ShowDialog() == DialogResult.OK)
            {
                var filtros = filtro.Resultado;

                estoqueController.GetEstoquetByFilter(filtros, ref listView1);
            }
        }

        private async void toolStripButton_importar_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<Produtos> sd = estoqueController.GetAllProduct();
                await ExcelImporter.ImportarEstoque(ofd.FileName, sd);
                estoqueController.GetAllEstoque(ref listView1);
                MessageBox.Show("Importação concluída com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton_entrada_Click(object sender, EventArgs e)
        {
            (new EntradaProduto()).ShowDialog();
            produtosCurrent = estoqueController.GetAllEstoque(ref listView1);
        }
    }
}
