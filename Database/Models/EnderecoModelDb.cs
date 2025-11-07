using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("ENDERECO")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("enderecoId")]
        public string EnderecoId { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("coluna")]
        public string Coluna { get; set; }

        [Column("palete")]
        public string Palete { get; set; }

        public ICollection<Estoque> Estoque { get; set; } = new List<Estoque>();
    }


}
