using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View;
namespace MapaEstoqueCD
{
    public partial class MainWindow : Form
    {
        public CacheMP Cache { get; private set; }

        public MainWindow()
        {
            Cache = CacheMP.Instance;
            InitializeComponent();
            ChekcedLogin();






        }



        public void ChekcedLogin()
        {
            var tempLogin = new AccessUser();
            tempLogin.ShowDialog();
            if (!tempLogin.isLoagin)
                Environment.Exit(0);

            toolStripStatusLabel_infoUser.Text =  $"{Cache.UserCurrent.Name.ToUpper()} -  {Cache.UserCurrent.Role}";
        }

        private void toolStripButton_movimentacao_Click(object sender, EventArgs e) => OpenForm.OpenFormToForm(new MovimentacaoForm(), ref paneL_center);

        private void toolStripButton_produto_Click(object sender, EventArgs e) => OpenForm.OpenFormToForm(new ProdutoForm(), ref paneL_center);
    }
}
