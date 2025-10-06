using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;

namespace MapaEstoqueCD.Services
{
    public class UserService
    {



        public User? Login(string username, string password)
        {
            string hash = AuthHelper.HashPassword(password);

            return CacheMP.Instance.Db.Users.FirstOrDefault(u => u.Name == username && u.Password == hash);
        }
    }
}
