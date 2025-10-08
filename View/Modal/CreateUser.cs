using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;

namespace MapaEstoqueCD.View.Modal
{
    public partial class CreateUser : Form
    {
        private readonly AdminController _adminController = new();
        private bool isEdit = false;
        private User UserCurrent = null;
        public CreateUser(User? user = null)
        {
            InitializeComponent();
            Clear();
            if (user != null)
            {
                UserCurrent = user;
                isEdit = true;
                this.Text = "Editar Usuário";
                textBox_user.Text = user.Name;
                groupBox1.Visible = false;
                comboBox_acesso.SelectedItem = user.Role?.ToString();
            }
        }

        private void Clear()
        {
            textBox_user.Clear();
            textBox_pass.Clear();
            comboBox_acesso.SelectedItem = 2;
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                bool x = _adminController.UpdateUser(new User { UserId = UserCurrent.UserId, Name = textBox_user.Text,Password= UserCurrent.Password, Role = (UserRole)Enum.Parse(typeof(UserRole), comboBox_acesso.SelectedItem.ToString()!) });
                if (x)
                {
                    MessageBox.Show("Usuário atualizado com sucesso!");
                    this.Close();
                }
            }
            else
            {

                if (string.IsNullOrWhiteSpace(textBox_pass.Text))
                {
                    MessageBox.Show("A senha é obrigatória para criar um usuário.");
                    return;
                }
                bool x =  _adminController.CreateUser(new User { Name = textBox_user.Text, Password = AuthHelper.HashPassword(textBox_pass.Text), Role = (UserRole)Enum.Parse(typeof(UserRole), comboBox_acesso.SelectedItem.ToString()!) });

                if (!x)
                {
                    MessageBox.Show("Erro ao criar usuário. Verifique se o nome de usuário já não existe.");
                    return;
                }
            }
        }
    }
}
