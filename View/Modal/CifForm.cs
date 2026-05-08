using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;

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
                //MessageBox.Show("CIF salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            }
            else if (dataGridView1.CurrentRow != null)
            {
                id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            }

            if (id > 0)
            {
                _cifsController.ExcluirCif(id);
                LoadData();
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var hit = dataGridView1.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                int rowIndex = hit.RowIndex;

                dataGridView1.ClearSelection();
                dataGridView1.Rows[rowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[Math.Max(0, hit.ColumnIndex)];
            }
        }
    }
}
