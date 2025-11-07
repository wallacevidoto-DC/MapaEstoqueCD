using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;

namespace MapaEstoqueCD.View
{
    public partial class AccessUser : Form
    {
        public bool isLoagin = false;
        
        public readonly UserController userController = new();
        public AccessUser()
        {
            InitializeComponent();
            //CacheMP.Instance.Db.Users.AddAsync(new User { Name = "dev", Password = AuthHelper.HashPassword("123"), Role = UserRole.DEV }).GetAwaiter().GetResult();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isLoagin = false;
            this.Close();
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            if (textBox_user.Text != string.Empty && textBox_pass.Text != string.Empty)
            {
                bool success = userController.Login(textBox_user.Text, textBox_pass.Text);

                if (success)
                {
                    isLoagin = true;
                    this.Close();
                }
                else { MessageBox.Show("Usuário ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
