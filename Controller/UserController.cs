using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;

namespace MapaEstoqueCD.Controller
{
    public class UserController
    {
        private readonly UserService userService = new();
        public UserController()
        {
                
        }


        public bool Login(string user, string pass)
        {
            User? userCurrent = userService.Login(user, pass) ?? null;

            if (userCurrent != null)
            {
                CacheMP.Instance.UserCurrent = userCurrent;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}