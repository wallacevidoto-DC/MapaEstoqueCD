using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Utils;

namespace MapaEstoqueCD.View.Modal
{
    public partial class CorrecaoProduto : Form
    {
        private readonly EstoqueWsDto estoqueDto;
        private readonly EstoqueController estoqueController = new();
        private ProdutoSpDto dto;
        public CorrecaoProduto(EstoqueWsDto estoqueWsDto)
        {
            InitializeComponent();

            this.estoqueDto = estoqueWsDto;
            Load(estoqueWsDto);
        }

        private void Load(EstoqueWsDto estoqueWsDto)
        {
            textBox_cod.Clear();
            textBox_decricao.Clear();
            textBox_qtd.Clear();
            maskedTextBox_datef.Clear();
            textBox_semf.Clear();
            textBox_lote.Clear();

            if (estoqueWsDto is not null)
            {
                textBox_cod.Text = estoqueWsDto.produto.codigo;
                textBox_decricao.Text = estoqueWsDto.produto.descricao;
                textBox_qtd.Text = estoqueWsDto.quantidade.ToString();
                maskedTextBox_datef.Text = DataFormatter.FormatarData(estoqueWsDto.dataF);
                textBox_semf.Text = estoqueWsDto.semF.ToString();
                textBox_lote.Text = estoqueWsDto.lote;

                richTextBox_obs.Focus();

                dto = new ProdutoSpDto
                {
                    id = estoqueWsDto.produtoId,
                    codigo = estoqueWsDto.produto.codigo,
                    descricao = estoqueWsDto.produto.descricao
                };
            }
        }

        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            dto.SetProps(int.Parse(textBox_qtd.Text.Trim()), maskedTextBox_datef.Text.Trim(), int.Parse(textBox_semf.Text.Trim()), textBox_lote.Text.Trim());

            if (!dto.IsValid(out string erro))
            {
                MessageBox.Show(erro, "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (estoqueController.SetCorrecaoProduto(new CorrecaoDto { observacao=richTextBox_obs.Text,produto=dto,enderecoId=estoqueDto.estoqueId}))
            {
                MessageBox.Show("Correção realizada com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao realizar a correção!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
