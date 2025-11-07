using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Database.Dto
{
    public class MovimentacaoDto
    {
        public int movimentacaoId { get; set; }
        public int estoqueId { get; set; }

        public string? usuarioNome { get; set; }

        public string? produtoCodigo { get; set; }
        public string? produtoDescricao { get; set; }

        public string? tipo { get; set; }
        public DateTime dataF { get; set; }
        public int semF { get; set; }
        public int quantidade { get; set; }
        public string? lote { get; set; }
        public string? obs { get; set; }
        public DateTime createAt { get; set; }
    }
}
