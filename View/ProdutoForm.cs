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
            Grids.SetDefaultListViews(produtosController.Columns, ref listView1);
            produtosCurrent = produtosController.GetAllProduct(ref listView1);

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

            //var filtros = new List<FiltroItem>
            //    {
            //        new FiltroItem { Coluna = "NCM", Valor = "Café", Tipo = "contém", Tabela = "Ncm" },
            //        new FiltroItem { Coluna = "Descrição", Valor = "Bebidas", Tipo = "exato", Tabela = "Descricao" }
            //    };

            //var form = new FiltroAvancadoForm(produtosController.Columns, filtros);
            //form.ShowDialog();

            using var filtro = new FiltroAvancadoForm(produtosController.Columns, filtrosAtivos);



            if (filtro.ShowDialog() == DialogResult.OK)
            {
                //filtrosAtivos = filtro.Resultado;
                var filtros = filtro.Resultado;

                produtosController.GetProductByFilter(filtros, ref listView1);
            }
        }

        private void toolStripButton_cadastrar_Click(object sender, EventArgs e)
        {
            (new ProdutoEdit()).ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                string valorPrimeiraCelula = item.SubItems[0].Text;

                (new ProdutoEdit(produtosController.GetByCod(valorPrimeiraCelula))).ShowDialog();
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
                produtosController.GetAllProduct(ref listView1);
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
    }
}
