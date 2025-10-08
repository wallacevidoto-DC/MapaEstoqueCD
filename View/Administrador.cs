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
            (new CreateUser()).ShowDialog();
            _adminController.GetAllUser(ref listView1);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                int valorPrimeiraCelula = Convert.ToInt32(item.SubItems[0].Text);

                (new CreateUser(_adminController.GetByCod(valorPrimeiraCelula))).ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada!");
            }
        }
    }


    public class AdminController
    {
        public readonly Dictionary<string, string> ColumnsUser;
        private readonly ProdutoService _produtoService = new();
        private readonly AppDbContext _db;


        public AdminController()
        {
            _db = CacheMP.Instance.Db;

            ColumnsUser = new Dictionary<string, string>
            {
                { "ID", nameof(User.UserId) },
                { "Nome", nameof(User.Name) },
                { "Acesso", nameof(User.Role) },                
                { "Data de Criação", nameof(User.CreateAt) }
            };
        }





        public List<User> GetAllUser(ref ListView listView)
        {
            listView.Items.Clear();
            List<User> produtos = CacheMP.Instance.Db.Users.ToList();

            foreach (var p in produtos)
            {
                var valores = ColumnsUser.Values.Select(propName =>
                {
                    var prop = typeof(User).GetProperty(propName);
                    var val = prop?.GetValue(p);
                    return val?.ToString() ?? "";
                }).ToArray();



                listView.Items.Add(new ListViewItem(valores));
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            return produtos;
        }

        public User? GetByCod(int valorPrimeiraCelula)
        {
            return CacheMP.Instance.Db.Users.First(x => x.UserId == valorPrimeiraCelula);
        }

        public bool CreateUser(User user)
        {
            try
            {
                CacheMP.Instance.Db.Users.Add(user);
                CacheMP.Instance.Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var local = CacheMP.Instance.Db.Users.Local.FirstOrDefault(x => x.UserId == user.UserId);
                if (local != null)
                {
                    _db.Entry(local).State = EntityState.Detached;
                }

                _db.Users.Update(user);
                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
    }
}
