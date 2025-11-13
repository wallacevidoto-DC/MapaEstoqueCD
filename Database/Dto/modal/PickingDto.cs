using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Database.Dto.modal
{
    public class PickingDto
    {
        public string tipo = "PICKING";

        public DateTime dataEntrada { get; set; }

        public string observacao { get; set; }


        public int userId { get; set; }
        public List<ProdutoSpDto> produtos { get; set; }
    }
}
