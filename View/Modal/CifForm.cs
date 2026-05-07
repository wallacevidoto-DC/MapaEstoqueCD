using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MapaEstoqueCD.View.Modal
{
    public partial class CifForm : Form
    {
        private readonly CifsController _cifsController = new();
        private int _currentCifId = 0;

        public CifForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            List<Cifs> cifs = _cifsController.GetAllCifs();

            foreach (var cif in cifs)
            {
                dataGridView1.Rows.Add(cif.CifId, cif.CifCod, cif.CreateAt?.ToString("dd/MM/yyyy HH:mm"));
            }
            
            textBox_cod.Clear();
            _currentCifId = 0;
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                _cifsController.SaveCif(textBox_cod.Text, _currentCifId);
                LoadData();
                MessageBox.Show("CIF salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar CIF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_gerar_Click(object sender, EventArgs e)
        {
            textBox_cod.Text = _cifsController.GerarProximoCif();
            _currentCifId = 0; // Se gerar novo, reseta o ID de edição
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                _currentCifId = (int)row.Cells[0].Value;
                textBox_cod.Text = row.Cells[1].Value.ToString();
            }
            else if (dataGridView1.CurrentRow != null)
            {
                var row = dataGridView1.CurrentRow;
                _currentCifId = (int)row.Cells[0].Value;
                textBox_cod.Text = row.Cells[1].Value.ToString();
            }
        }
    }
}
