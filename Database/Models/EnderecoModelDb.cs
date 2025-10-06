using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("ENDERECO")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string EnderecoId { get; set; } = string.Empty; // mapeado no OnModelCreating

        public required string Barracao { get; set; }
        public required string Rua { get; set; }
        public required string Coluna { get; set; }
        public required string Palete { get; set; }

        public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
    }

}
