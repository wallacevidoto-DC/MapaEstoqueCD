using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;
using Microsoft.EntityFrameworkCore;

namespace MapaEstoqueCD.View
{
    public partial class Administrador : Form
    {
        private readonly AdminController _adminController = new();

        public Administrador()
        {
            InitializeComponent();

            Grids.SetDefaultListViews(_adminController.ColumnsUser, ref listView1);
            _adminController.GetAllUser(ref listView1);
        }

        private void toolStripButton_cadastrar_Click(object sender, EventArgs e)
        {
            new CreateUser().ShowDialog();
            _adminController.GetAllUser(ref listView1);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nenhuma linha selecionada!");
                return;
            }

            ListViewItem item = listView1.SelectedItems[0];
            if (!int.TryParse(item.SubItems[0].Text, out int userId))
            {
                MessageBox.Show("Erro ao obter o ID do usuário!");
                return;
            }

            var user = _adminController.GetByCod(userId);
            if (user == null)
            {
                MessageBox.Show("Usuário não encontrado!");
                return;
            }

            new CreateUser(user).ShowDialog();
            _adminController.GetAllUser(ref listView1);
        }
    }

    public class AdminController
    {
        public readonly List<ColumnConfig> ColumnsUser;
        private readonly AppDbContext _db;

        public AdminController()
        {
            _db = CacheMP.Instance.Db;

            ColumnsUser = new List<ColumnConfig>
            {
                new ColumnConfig("ID", nameof(User.UserId)),
                new ColumnConfig("Nome", nameof(User.Name)),
                new ColumnConfig("Acesso", nameof(User.Role)),
                new ColumnConfig("Data de Criação", nameof(User.CreateAt))
            };
        }

        public List<User> GetAllUser(ref ListView listView)
        {
            listView.Items.Clear();

            var users = _db.Users.ToList();
            if (CacheMP.Instance.UserCurrent.Role != UserRole.DEV)
            {
                users = users.Where(x => x.Role != UserRole.DEV).ToList();
            }
            var columns = ColumnsUser.Where(c => c.Visivel).ToList();

            listView.Columns.Clear();
            foreach (var col in columns)
                listView.Columns.Add(col.Titulo);

            foreach (var u in users)
            {
                var valores = columns.Select(c =>
                {
                    object? val = null;

                    if (c.Propriedade.Contains("."))
                    {
                        var parts = c.Propriedade.Split('.');
                        object? currentObj = u;

                        foreach (var part in parts)
                        {
                            if (currentObj == null) break;
                            var prop = currentObj.GetType().GetProperty(part);
                            currentObj = prop?.GetValue(currentObj);
                        }

                        val = currentObj;
                    }
                    else
                    {
                        var prop = typeof(User).GetProperty(c.Propriedade);
                        val = prop?.GetValue(u);
                    }

                    return val?.ToString() ?? "";
                }).ToArray();

                listView.Items.Add(new ListViewItem(valores));
            }
            listView.Font = new Font(listView.Font.FontFamily, 20); // tamanho 14
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            
            return users;
        }

        public User? GetByCod(int userId)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == userId);
        }

        public bool CreateUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetErro(user);
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var local = _db.Users.Local.FirstOrDefault(x => x.UserId == user.UserId);
                if (local != null)
                    _db.Entry(local).State = EntityState.Detached;

                if (local.Password != user.Password)
                {

                    user .Password = AuthHelper.HashPassword(user.Password);
                }
                _db.Users.Update(user);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetErro(user);
                return false;
            }
        }
    }
}
