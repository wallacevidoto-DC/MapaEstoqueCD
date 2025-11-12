using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;

namespace MapaEstoqueCD.View.Modal
{
    public partial class TransferenciaProduto : Form
    {
        private readonly EstoqueWsDto estoqueDto;
        private readonly EstoqueController estoqueController = new();
        private List<ProdutoSpDto> produtoSpDtos = new();
        private TranferenciaDto transferenciaDto;

        public TransferenciaProduto(EstoqueWsDto estoqueWsDto)
        {
            InitializeComponent();

            this.estoqueDto = estoqueWsDto;
            Load(estoqueWsDto);
        }

        private void Load(EstoqueWsDto estoqueWsDto)
        {


            textBox_atualx.Text = $"ENDEREÇO ATUAL : {estoqueWsDto.enderecoId}";

            produtoSpDtos.Add(new ProdutoSpDto
            {
                produtoId = estoqueWsDto.produtoId,
                codigo = estoqueWsDto.produto.codigo,
                descricao = estoqueWsDto.produto.descricao,
                quantidade = estoqueWsDto.quantidade,
                dataf = estoqueWsDto.dataF,
                semf = estoqueWsDto.semF,
                lote = estoqueWsDto.lote,
                propsPST =
                                      {
                                        isModified = false,
                                        origem = Origem.OUT
                                      }
            });
            ReloadGrid();




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

        public void RemoveIN()
        {
            produtoSpDtos = produtoSpDtos.Where(p => p.propsPST.origem != Origem.IN).ToList();
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
                transferenciaDto = new TranferenciaDto
                {
                    estoqueID = estoqueDto.estoqueId,
                    rua = comboBox_rua.Text,
                    bloco = comboBox_bloco.Text,
                    apt = comboBox_apt.Text,
                    endOld = estoqueDto.enderecoId,
                    observacao = richTextBox_obs.Text,
                    dataEntrada= estoqueDto.dataL,
                    produto = produtoSpDtos.FirstOrDefault(p => p.propsPST.origem == Origem.OUT),
                };

                if (estoqueController.SetTranferencia(transferenciaDto))
                {
                    this.Close();
                    //MessageBox.Show(Text = "Transferência registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //var dr = MessageBox.Show("Deseja registrar outra entrada?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (dr == DialogResult.No)
                    //{
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    produtoSpDtos.Clear();
                    //    ReloadGrid();
                    //    comboBox_rua.Text = "";
                    //    comboBox_bloco.Text = "";
                    //    comboBox_apt.Text = "";
                    //    richTextBox_obs.Text = "";
                    //    dateTimePicker_dataEntrada.Value = DateTime.Now;
                    //}
                }
            }

        }

    }
}
