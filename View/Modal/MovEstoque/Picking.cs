using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;

namespace MapaEstoqueCD.View.Modal
{
    public partial class Picking : Form
    {
        private readonly EstoqueController estoqueController = new();

        private List<ProdutoSpDto> produtoSpDtos = new();

        private PickingDto pickingDto;

        public Picking()
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

                //if (p.propsPST.origem == Origem.IN)
                //{
                //    row.DefaultCellStyle.BackColor = Color.FromArgb(204, 255, 204);
                //}
                //else if (p.propsPST.origem == Origem.OUT)
                //{
                //    row.DefaultCellStyle.BackColor = Color.FromArgb(204, 229, 255);
                //}

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

        private void button_salvar_Click(object sender, EventArgs e)
        {
            if (produtoSpDtos.Count > 0)
            {
                pickingDto = new PickingDto
                {
                    dataEntrada = dateTimePicker_dataEntrada.Value,
                    observacao = richTextBox_obs.Text,
                    produtos = produtoSpDtos.Where(p => p.propsPST.origem == Origem.OUT).ToList(),
                };

                if (estoqueController.SetPicking(pickingDto))
                {
                    MessageBox.Show(Text = "Picking registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var dr = MessageBox.Show("Deseja registrar outra picking?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) { 
                        this.Close();
                    }
                    else
                    {
                        produtoSpDtos.Clear();
                        ReloadGrid();
                        richTextBox_obs.Clear();
                        dateTimePicker_dataEntrada.Value = DateTime.Now;
                    }
                }
            }

        }
    }
}
