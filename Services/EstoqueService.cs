using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Services
{
    public class EstoqueService
    {
        public EstoqueService()
        {
                
        }
        public List<Estoque> GetAll()
        {
            return CacheMP.Instance.Db.Estoques.ToList();
        }
    }
}
