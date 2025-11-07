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
    public partial class EntradaProduto : Form
    {
        public EntradaProduto()
        {
            InitializeComponent();
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
