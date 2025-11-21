using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace MapaEstoqueCD.View.Modal
{
    public partial class CorrecaoEntrada : Form
    {
        private readonly CorrecaoEntradaDto entrdaCDto;
        private readonly EntradasControllers entradaController = new();
        private ProdutoSpDto dto;
        public CorrecaoEntrada(CorrecaoEntradaDto estoqueWsDto)
        {
            InitializeComponent();

            this.entrdaCDto = estoqueWsDto;
            Load(estoqueWsDto);
        }

        private void Load(CorrecaoEntradaDto estoqueWsDto)
        {
            textBox_cod.Clear();
            textBox_decricao.Clear();
            textBox_qtd.Clear();
            maskedTextBox_datef.Clear();
            textBox_semf.Clear();
            textBox_lote.Clear();

            if (estoqueWsDto is not null)
            {
                var ent = CacheMP.Instance.Db.Entradas.FirstOrDefault(e => e.EntradaId == estoqueWsDto.conferenciaId);

                if (ent.Produto is null)
                {
                    ent.Produto = CacheMP.Instance.Db.Produtos.FirstOrDefault(e => e.ProdutoId == ent.ProdutoId);
                }


                if (ent is null)
                {
                    MessageBox.Show("Erro");
                    return;
                }
                textBox_cod.Text = ent.Produto.Codigo;
                textBox_decricao.Text = ent.Produto.Descricao;
                textBox_qtd.Text = estoqueWsDto.qtd_conferida.ToString();
                maskedTextBox_datef.Text = DataFormatter.FormatarData(estoqueWsDto.dataf);
                textBox_semf.Text = estoqueWsDto.semf.ToString();
                textBox_lote.Text = estoqueWsDto.lote; ;

                //dto = new ProdutoSpDto
                //{
                //    produtoId = estoqueWsDto.produtoId,
                //    codigo = estoqueWsDto.produto.codigo,
                //    descricao = estoqueWsDto.produto.descricao
                //};
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
            //dto.SetProps(int.Parse(textBox_qtd.Text.Trim()), maskedTextBox_datef.Text.Trim(), int.Parse(textBox_semf.Text.Trim()), textBox_lote.Text.Trim());

            //if (!dto.IsValid(out string erro))
            //{
            //    MessageBox.Show(erro, "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (entradaController.SetCorrecaoEntrada(new CorrecaoEntradaDto
            {
                conferenciaId = entrdaCDto.conferenciaId,
                qtd_conferida = Convert.ToInt32(textBox_qtd.Text),
                dataf = maskedTextBox_datef.Text,
                semf = Convert.ToInt32(textBox_semf.Text),
                lote = textBox_lote.Text
            }))
            {
                MessageBox.Show("Correção realizada com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao realizar a correção!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
