using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Common;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;

namespace MapaEstoqueCD.Services
{
    public class UserService
    {
        public User? Login(string username, string password)
        {
            using var db = ContextFactory.CreateDb();
            string hash = AuthHelper.HashPassword(password);

            return db.Users.FirstOrDefault(u => u.Name == username && u.Password == hash);
        }
    }
}
