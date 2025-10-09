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
        public int EnderecoId { get; set; }

        [Column("rua")]
        public required string Rua { get; set; } = string.Empty;

        [Column("coluna")]
        public required string Coluna { get; set; }= string.Empty;

        [Column("palete")]
        public required string Palete { get; set; }= string.Empty;

        public ICollection<Estoque> Estoque { get; set; } = new List<Estoque>();
    }

}
