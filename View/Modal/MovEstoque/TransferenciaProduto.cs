using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaEstoqueCD.View.Modal
{
    public partial class TransferenciaProduto : Form
    {
        private readonly EstoqueWsDto estoqueDto;
        private readonly EstoqueController estoqueController = new();
        private List<ProdutoSpDto> produtoSpDtos = new();

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
                
            });





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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_addProd_Click(object sender, EventArgs e)
        {
            (new AdicionarProduto()).ShowDialog();
        }
    }
}
