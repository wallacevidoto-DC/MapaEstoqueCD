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

namespace MapaEstoqueCD.View.Modal.Controls
{
    public partial class FilterControl : UserControl
    {
        public event EventHandler? DeleteClicked;
        public event EventHandler? ValueChanged;

        public FilterControl()
        {
            InitializeComponent();


            comboBox_columns.SelectedIndexChanged += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);
            textBox_value.TextChanged += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);
            pictureBox_delete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetComboItems(List<ColumnConfig> columns)
        {
            comboBox_columns.DataSource = null;
            comboBox_columns.DisplayMember = "Titulo";     
            comboBox_columns.ValueMember = "Propriedade";  
            comboBox_columns.DataSource = columns;
        }

        public string SelectedItem => comboBox_columns.Text;
        public string SelectedProperty => comboBox_columns.SelectedValue?.ToString() ?? string.Empty;
        public string InputText => textBox_value.Text;

        public void SetSelectedProperty(string propriedade)
        {
            comboBox_columns.SelectedValue = propriedade;
        }

        public void SetText(string value)
        {
            textBox_value.Text = value;
        }
    }
}
