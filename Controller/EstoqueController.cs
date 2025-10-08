using MapaEstoqueCD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Controller
{
    public class EstoqueController
    {
        public readonly EstoqueService estoqueService = new();
        public EstoqueController()
        {
            
        }
    }
}
