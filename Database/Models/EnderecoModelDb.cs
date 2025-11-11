using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("ENDERECO")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string EnderecoId { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("coluna")]
        public string Coluna { get; set; }

        [Column("palete")]
        public string Palete { get; set; }

        public ICollection<Estoque> Estoque { get; set; } = new List<Estoque>();



        public void GerarEnderecoId()
        {
            EnderecoId = $"{Rua}{Coluna}{Palete}";
        }
    }


}
