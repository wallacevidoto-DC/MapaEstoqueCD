using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;

namespace MapaEstoqueCD.View.Modal
{
    public partial class AdicionarProduto : Form
    {
        private ProdutoSpDto dto;
        public AdicionarProduto()
        {
            InitializeComponent();

            Load();
        }

        private void Load()
        {
            textBox_cod.Clear();
            textBox_decricao.Clear();
            textBox_qtd.Clear();
            maskedTextBox_datef.Clear();
            textBox_semf.Clear();
            textBox_lote.Clear();

            maskedTextBox_datef.ValidatingType = typeof(DateTime);
        }

        private void textBox_cod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                var prod = CacheMP.Instance.Db.Produtos.FirstOrDefault(e => e.Codigo == textBox_cod.Text.Trim());
                if (prod != null)
                {
                    textBox_decricao.Text = prod.Descricao;
                    dto = new ProdutoSpDto
                    {
                        produtoId = prod.ProdutoId,
                        codigo = prod.Codigo,
                        descricao = prod.Descricao,
                        propsPST =
                        {
                            isModified = true,
                            origem = Origem.OUT
                        }
                    };
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_cod.Clear();
                    textBox_decricao.Clear();
                }
            }
        }

        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox_datef_Leave(object sender, EventArgs e)
        {
            string[] partes = maskedTextBox_datef.Text.Split('/');
            if (partes.Length == 2 &&
                int.TryParse(partes[0], out int mes) &&
                (mes < 1 || mes > 12))
            {
                MessageBox.Show("Mês inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox_datef.Focus();
            }
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            if (dto == null)
            {
                MessageBox.Show("Selecione um produto antes de salvar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_qtd.Text) ||
                string.IsNullOrWhiteSpace(textBox_semf.Text))
            {
                MessageBox.Show("Preencha todos os campos numéricos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dto.SetProps(int.Parse(textBox_qtd.Text.Trim()),maskedTextBox_datef.Text,int.Parse(textBox_semf.Text.Trim()),textBox_lote.Text.Trim());

            if (!dto.IsValid(out string erro))
            {
                MessageBox.Show(erro, "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static ProdutoSpDto? ShowDialogAndReturn()
        {
            using (var form = new AdicionarProduto())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    return form.dto;
                return null; 
            }
        }
    }
}
