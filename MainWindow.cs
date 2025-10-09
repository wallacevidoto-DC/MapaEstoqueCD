using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View;
using MapaEstoqueCD.WebSocketActive;
namespace MapaEstoqueCD
{
    public partial class MainWindow : Form
    {
        public CacheMP Cache { get; private set; }
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            Instance = this;
            Cache = CacheMP.Instance;
            InitializeComponent();
            ChekcedLogin();
            WebSocketService.Instance.ConnectEvents();
        }



        public void ChekcedLogin()
        {
            var tempLogin = new AccessUser();
            tempLogin.ShowDialog();
            if (!tempLogin.isLoagin)
                Environment.Exit(0);

            toolStripStatusLabel_infoUser.Text = $"{Cache.UserCurrent.Name.ToUpper()} -  {Cache.UserCurrent.Role}";


            if (!ControlAccess.IsSupers())
            {
                toolStripButton_adm.Visible = false;
                toolStripSeparator5.Visible = false;
            }
        }

        private void toolStripButton_movimentacao_Click(object sender, EventArgs e) => OpenForm.OpenFormToForm(new MovimentacaoForm(), ref paneL_center);

        private void toolStripButton_produto_Click(object sender, EventArgs e) => OpenForm.OpenFormToForm(new ProdutoForm(), ref paneL_center);

        private void toolStripButton_adm_Click(object sender, EventArgs e) => OpenForm.OpenFormToForm(new Administrador(), ref paneL_center);

        private void toolStripButton_remoto_Click(object sender, EventArgs e) => OpenForm.OpenFormToForm(new ServerView(), ref paneL_center);

        private void toolStripButton_estoque_Click(object sender, EventArgs e) => OpenForm.OpenFormToForm(new EstoqueForm(), ref paneL_center);
    }
}
