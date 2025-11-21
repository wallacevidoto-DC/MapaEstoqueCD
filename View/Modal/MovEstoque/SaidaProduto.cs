using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Utils;

namespace MapaEstoqueCD.View.Modal
{
    public partial class SaidaProduto : Form
    {
        private readonly EstoqueWsDto estoqueDto;
        private readonly EstoqueController estoqueController = new();
        public SaidaProduto(EstoqueWsDto estoqueWsDto)
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
            textBox_qtd_ret.Clear();

            if (estoqueWsDto is not null)
            {
                textBox_cod.Text = estoqueWsDto.produto.codigo;
                textBox_decricao.Text = estoqueWsDto.produto.descricao;
                textBox_qtd.Text = estoqueWsDto.quantidade.ToString();
                maskedTextBox_datef.Text = DataFormatter.FormatarMesAno(estoqueWsDto.dataF);
                textBox_semf.Text = estoqueWsDto.semF.ToString();
                textBox_lote.Text = estoqueWsDto.lote;

                textBox_qtd_ret.Focus();

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

            if (textBox_qtd_ret.Text == "" || int.Parse(textBox_qtd_ret.Text) <= 0)
            {
                MessageBox.Show("Quantidade inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (estoqueController.SetSaida(new SaidaDto
            {
                estoqueId = estoqueDto.estoqueId,
                qtdRetirada = int.Parse(textBox_qtd_ret.Text),
                observacao = richTextBox_obs.Text
            }))
            {
                MessageBox.Show("Saída registrada com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
           
        }
    }
}