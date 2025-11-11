using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Models;

namespace MapaEstoqueCD.View.Modal
{
    public partial class EntradaProduto : Form
    {
        private readonly EstoqueController estoqueController = new();

        private List<ProdutoSpDto> produtoSpDtos = new();

        private EntradaDto entradaDto;

        public EntradaProduto()
        {
            InitializeComponent();
        }

        public void ReloadGrid()
        {
            dataGridView_produtos.Rows.Clear();

            if (produtoSpDtos == null || produtoSpDtos.Count == 0)
                return;

            for (int i = 0; i < produtoSpDtos.Count; i++)
            {
                var p = produtoSpDtos[i];


                int rowIndex = dataGridView_produtos.Rows.Add(
                    i,
                    p.codigo,
                    p.descricao,
                    p.quantidade,
                    p.dataf,
                    p.semf,
                     p.lote, ""
                                    );

                var row = dataGridView_produtos.Rows[rowIndex];

                if (p.propsPST.origem == Origem.IN)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(204, 255, 204);
                }
                else if (p.propsPST.origem == Origem.OUT)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(204, 229, 255);
                }

                if (p.propsPST.origem == Origem.OUT)
                {
                    row.Cells["acao"].Value = "🗑️";
                    row.Cells["acao"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                row.Tag = i;
            }

            dataGridView_produtos.ClearSelection();
        }

        public void RemoveIN()
        {
            produtoSpDtos = produtoSpDtos.Where(p => p.propsPST.origem != Origem.IN).ToList();
        }

        private void dataGridView_produtos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView_produtos.Columns["acao"].Index)
                return;

            var row = dataGridView_produtos.Rows[e.RowIndex];
            int index = (int)row.Tag;
            var produto = produtoSpDtos[index];

            if (produto.propsPST.origem != Origem.OUT)
                return;

            var confirmar = MessageBox.Show(
                $"Deseja remover o produto '{produto.descricao}'?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmar == DialogResult.Yes)
            {
                produtoSpDtos.RemoveAt(index);
                ReloadGrid();
            }
        }


        private void button_addProd_Click(object sender, EventArgs e)
        {
            var produto = AdicionarProduto.ShowDialogAndReturn();

            if (produto != null)
            {


                produtoSpDtos.Add(produto);
                ReloadGrid();
            }
            else
            {
                MessageBox.Show("Operação cancelada.");
            }

        }

        private void button_bucar_end_Click(object sender, EventArgs e)
        {
            if (comboBox_rua.Text != "" && comboBox_bloco.Text != "" && comboBox_apt.Text != "")
            {
                List<ProdutoSpDto> endereco = estoqueController.estoqueService.GetEnderecoByDetails(
                    comboBox_rua.Text,
                    comboBox_bloco.Text,
                    comboBox_apt.Text
                );
                if (endereco != null)
                {
                    RemoveIN();
                    produtoSpDtos.AddRange(endereco);
                    ReloadGrid();
                }
                else
                {
                    //MessageBox.Show("Endereço não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha Rua, Bloco e Apt antes de buscar o endereço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            if (comboBox_rua.Text != "" && comboBox_bloco.Text != "" && comboBox_apt.Text != "")
            {
                entradaDto = new EntradaDto
                {
                    rua = comboBox_rua.Text,
                    bloco = comboBox_bloco.Text,
                    apt = comboBox_apt.Text,
                    dataEntrada = dateTimePicker_dataEntrada.Value,
                    observacao = richTextBox_obs.Text,
                    produtos = produtoSpDtos.Where(p => p.propsPST.origem == Origem.OUT).ToList(),
                };

                if (estoqueController.SetEntrada(entradaDto))
                {
                    MessageBox.Show(Text = "Entrada registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var dr = MessageBox.Show("Deseja registrar outra entrada?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) { 
                        this.Close();
                    }
                    else
                    {
                        produtoSpDtos.Clear();
                        ReloadGrid();
                        comboBox_rua.Text = "";
                        comboBox_bloco.Text = "";
                        comboBox_apt.Text = "";
                        richTextBox_obs.Text = "";
                        dateTimePicker_dataEntrada.Value = DateTime.Now;
                    }
                }
            }

        }
    }
}
