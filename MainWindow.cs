using MapaEstoqueCD.Controller;
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

            InitializeComponent();
            SetVisibleBar(false);
        }



        public void ChekcedLogin()
        {
            var tempLogin = new AccessUser();
            tempLogin.ShowDialog();
            if (!tempLogin.isLoagin)
                Environment.Exit(0);
            toolStripStatusLabel_infoUser.Text = $"{Cache.UserCurrent.Name.ToUpper()} -  {Cache.UserCurrent.Role}";
            SetVisibleBar(true);

            if (!ControlAccess.IsSupers())
            {
                toolStripButton_adm.Visible = false;
                toolStripSeparator5.Visible = false;
            }
        }
        private void ResetIMG()
        {
            toolStripButton_movimentacao.BackgroundImage = null;
            toolStripButton_produto.BackgroundImage = null;
            toolStripButton_adm.BackgroundImage = null;
            toolStripButton_remoto.BackgroundImage = null;
            toolStripButton_estoque.BackgroundImage = null;
            toolStripButton_entrada.BackgroundImage = null;

            toolStripButton_movimentacao.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_produto.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_adm.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_remoto.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_estoque.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_entrada.TextAlign = ContentAlignment.BottomCenter;
        }

        private void toolStripButton_movimentacao_Click(object sender, EventArgs e)
        {
            OpenForm.OpenFormToForm(new MovimentacaoForm(), ref paneL_center);
            ResetIMG();
            toolStripButton_movimentacao.BackgroundImage = Properties.Resources.select;
            toolStripButton_movimentacao.TextAlign = ContentAlignment.TopCenter;
        }

        private void toolStripButton_produto_Click(object sender, EventArgs e)
        {
            OpenForm.OpenFormToForm(new ProdutoForm(), ref paneL_center);
            ResetIMG();
            toolStripButton_produto.BackgroundImage = Properties.Resources.select;
            toolStripButton_produto.TextAlign = ContentAlignment.TopCenter;
        }

        private void toolStripButton_adm_Click(object sender, EventArgs e)
        {
            OpenForm.OpenFormToForm(new Administrador(), ref paneL_center);
            ResetIMG();
            toolStripButton_adm.BackgroundImage = Properties.Resources.select;
            toolStripButton_adm.TextAlign = ContentAlignment.TopCenter;
        }

        private void toolStripButton_remoto_Click(object sender, EventArgs e)
        {
            OpenForm.OpenFormToForm(new ServerView(), ref paneL_center);
            ResetIMG();
            toolStripButton_remoto.BackgroundImage = Properties.Resources.select;
            toolStripButton_remoto.TextAlign = ContentAlignment.TopCenter;
        }

        private void toolStripButton_estoque_Click(object sender, EventArgs e)
        {
            OpenForm.OpenFormToForm(new EstoqueForm(), ref paneL_center);
            ResetIMG();
            toolStripButton_estoque.BackgroundImage = Properties.Resources.select;
            toolStripButton_estoque.TextAlign = ContentAlignment.TopCenter;
        }

        private void toolStripButton_entrada_Click(object sender, EventArgs e)
        {
            OpenForm.OpenFormToForm(new EntradaForm(), ref paneL_center);
            ResetIMG();
            toolStripButton_entrada.BackgroundImage = Properties.Resources.select;
            toolStripButton_entrada.TextAlign = ContentAlignment.TopCenter;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                Instance = this;
                Cache = CacheMP.Instance;
                ChekcedLogin();
                ResetIMG();
                WebSocketService.Instance.ConnectEvents();
                toolStripButton_movimentacao_Click(null, null);
            }
            catch (Exception ex)
            {

                ex.GetErro("INICIAR O PROGRAMA");
            }

        }

        private void toolStripButton_logoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desejá mesmo sair?", "LOGOFF", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SetVisibleBar(false);
                CacheMP.Instance.UserCurrent = null;
                paneL_center.Controls.Clear();
                ChekcedLogin();
                ResetIMG();
                toolStripButton_movimentacao_Click(null, null);
            }
        }


        private void SetVisibleBar(bool b)
        {
            if (b)
            {
                paneL_center.BackgroundImage = null;
            }
            else
            {
                paneL_center.BackgroundImage = Properties.Resources.imgestoque;
            }
            toolStrip_menu.Visible = b;
            statusStrip_sub.Visible = b;

        }
    }
}
