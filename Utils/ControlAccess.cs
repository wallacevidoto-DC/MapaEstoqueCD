using MapaEstoqueCD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Utils
{
    public class ControlAccess
    {

        public static bool IsAdmin()
        {
            return CacheMP.Instance.UserCurrent.Role == Database.Models.UserRole.ADMIN;
        }

        public static bool IsDev()
        {
            return CacheMP.Instance.UserCurrent.Role == Database.Models.UserRole.DEV;
        }

        public static bool IsSupers()
        {
            return CacheMP.Instance.UserCurrent.Role == Database.Models.UserRole.DEV || CacheMP.Instance.UserCurrent.Role == Database.Models.UserRole.ADMIN;
        }
    }
}
