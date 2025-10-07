using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;

namespace MapaEstoqueCD.View.Modal
{
    public partial class ProdutoEdit : Form
    {
        private readonly ProdutosController produtosController = new();
        private Produtos? produtoAtual = null;
        private Image? imagemAtual = null;
        private bool isEditMode = false;

        public ProdutoEdit(Produtos? produto = null)
        {
            InitializeComponent();
            AplicarSomenteNumerosEVirgula(this);
            LimparTextBoxes(this);

            if (produto != null)
            {
                groupBox1.Text = "Editar Produto";
                isEditMode = true;
                produtoAtual = produto;
                SetProduto();
            }
        }


        private void SetProduto()
        {
            if (produtoAtual != null)
            {
                textBox_cod.Text = produtoAtual.Codigo;
                textBox_decricao.Text = produtoAtual.Descricao;
                textBox_ncm.Text = produtoAtual.Ncm;
                textBox_ipi.Text = produtoAtual.Ipi.ToString();
                textBox_pis.Text = produtoAtual.Pis.ToString();
                textBox_confins.Text = produtoAtual.Cofins.ToString();
                textBox_shelflife.Text = produtoAtual.ShelfLife;

                textBox_ucod.Text = produtoAtual.UCodigoBarras;
                textBox_uccm.Text = produtoAtual.UC.ToString();
                textBox_ulcm.Text = produtoAtual.UL.ToString();
                textBox_udcm.Text = produtoAtual.UD.ToString();
                textBox_uhcm.Text = produtoAtual.UH.ToString();
                textBox_ukgl.Text = produtoAtual.UPesoLiquido.ToString();
                textBox_ukgb.Text = produtoAtual.UPesoBruto.ToString();

                textBox_dcod.Text = produtoAtual.DCodigoBarras;
                textBox_dccm.Text = produtoAtual.DC.ToString();
                textBox_dlcm.Text = produtoAtual.DL.ToString();
                textBox_dhcm.Text = produtoAtual.DH.ToString();
                textBox_dkgl.Text = produtoAtual.DPesoLiquido.ToString();
                textBox_dkgb.Text = produtoAtual.DPesoBruto.ToString();
                textBox_dq.Text = produtoAtual.DQtd.ToString();

                textBox_ccod.Text = produtoAtual.CCodigoBarras;
                textBox_cccm.Text = produtoAtual.CC.ToString();
                textBox_clcm.Text = produtoAtual.CL.ToString();
                textBox_chcm.Text = produtoAtual.CH.ToString();
                textBox_cq.Text = produtoAtual.CQtd.ToString();
                textBox_ckgl.Text = produtoAtual.CPesoLiquido.ToString();
                textBox_ckgb.Text = produtoAtual.CPesoBruto.ToString();

                textBox_pcxl.Text = produtoAtual.PCxLastro.ToString();
                textBox_empcx.Text = produtoAtual.PEmpCx.ToString();
                textBox_pcxp.Text = produtoAtual.PCxPalete.ToString();

                
                if (produtoAtual.Produto != null)
                {
                    Image img = produtosController.CarregarImagemProduto(produtoAtual.Produto);
                    if(img != null)
                    {
                        pictureBox_imagem.Image = img;
                    }
                }
                else
                {
                    pictureBox_imagem.Image = Properties.Resources.sem_imagens__1_;
                }
            }
        }

        private void AplicarSomenteNumerosEVirgula(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt &&
                    txt.Name != "textBox_decricao" &&
                    txt.Name != "textBox_shelflife")
                {
                    txt.KeyPress += ApenasNumerosEVirgula;
                }
                if (ctrl.HasChildren)
                {
                    AplicarSomenteNumerosEVirgula(ctrl);
                }
            }
        }

        private void ApenasNumerosEVirgula(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && sender is TextBox txt && txt.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void LimparTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                }

                if (ctrl.HasChildren)
                {
                    LimparTextBoxes(ctrl);
                }
            }

            pictureBox_imagem.Image = Properties.Resources.sem_imagens__1_;
            imagemAtual = null;
        }

        private void button_buscar_img_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Selecione uma imagem";
                ofd.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox_imagem.Image = new Bitmap(ofd.FileName);
                        imagemAtual = new Bitmap(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                    }
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            LimparTextBoxes(this);
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_cod.Text) || string.IsNullOrWhiteSpace(textBox_decricao.Text))
            {
                MessageBox.Show("Os campos 'Código' e 'Descrição' são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {             

                Produtos produto = new Produtos
                {
                    Codigo = textBox_cod.Text.Trim(),
                    Descricao = textBox_decricao.Text.Trim(),
                    Ncm = textBox_ncm.Text.Trim(),
                    Ipi = decimal.TryParse(textBox_ipi.Text, out decimal ipi) ? ipi : (decimal?)null,
                    Pis = decimal.TryParse(textBox_pis.Text, out decimal pis) ? pis : (decimal?)null,
                    Cofins = decimal.TryParse(textBox_confins.Text, out decimal cofins) ? cofins : (decimal?)null,
                    ShelfLife = textBox_shelflife.Text,

                    // Unidade
                    UCodigoBarras = textBox_ucod.Text.Trim(),
                    UC = double.TryParse(textBox_uccm.Text, out double ccmUnit) ? ccmUnit : (double?)null,
                    UL = double.TryParse(textBox_ulcm.Text, out double lcmUnit) ? lcmUnit : (double?)null,                    
                    UH = double.TryParse(textBox_uhcm.Text, out double hcmUnit) ? hcmUnit : (double?)null,
                    UPesoLiquido = double.TryParse(textBox_ukgl.Text, out double plUnit) ? plUnit : (double?)null,
                    UPesoBruto = double.TryParse(textBox_ukgb.Text, out double pbUnit) ? pbUnit : (double?)null,

                    // Display
                    DCodigoBarras = textBox_dcod.Text.Trim(),
                    DC = double.TryParse(textBox_dccm.Text, out double ccmCaixa) ? ccmCaixa : (double?)null,
                    DL = double.TryParse(textBox_dlcm.Text, out double lcmCaixa) ? lcmCaixa : (double?)null,
                    
                    DPesoLiquido = double.TryParse(textBox_dkgl.Text, out double plCaixa) ? plCaixa : (double?)null,
                    DPesoBruto = double.TryParse(textBox_dkgb.Text, out double pbCaixa) ? pbCaixa : (double?)null,
                    DQtd = int.TryParse(textBox_dq.Text, out int qtdUnit) ? qtdUnit : (int?)null,

                    // Caixa
                    CCodigoBarras = textBox_ccod.Text.Trim(),
                    CC = double.TryParse(textBox_cccm.Text, out double ccmPalet) ? ccmPalet : (double?)null,
                    CL = double.TryParse(textBox_clcm.Text, out double lcmPalet) ? lcmPalet : (double?)null,
                    CH = double.TryParse(textBox_chcm.Text, out double hcmPalet) ? hcmPalet : (double?)null,
                    CQtd = int.TryParse(textBox_cq.Text, out int qtdCaixa) ? qtdCaixa : (int?)null,
                    CPesoLiquido = double.TryParse(textBox_ckgl.Text, out double plPalet) ? plPalet : (double?)null,
                    CPesoBruto = double.TryParse(textBox_ckgb.Text, out double pbPalet) ? pbPalet : (double?)null,

                    // Paletização
                    PCxLastro = int.TryParse(textBox_pcxl.Text, out int cxsLastro) ? cxsLastro : (int?)null,
                    PEmpCx = int.TryParse(textBox_empcx.Text, out int empCxs) ? empCxs : (int?)null,
                    PCxPalete = int.TryParse(textBox_pcxp.Text, out int cxsPalet) ? cxsPalet : (int?)null,

                    
                };

                //produtoAtual = produto;

                if (isEditMode)
                {
                    produto.ProdutoId = produtoAtual!.ProdutoId;
                    produtosController.UpdateProduct(produto, imagemAtual);
                }
                else
                {
                    produtosController.AddProduct(produto, imagemAtual);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
