using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("CIFS")]

    public class Cifs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cifId")]
        public int CifId { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        [Column("cirt")]
        public string Cirt { get; set; }

        [Column("produtoId")]
        public int? ProdutoId { get; set; }

        public Produtos Produto { get; set; }

        [Column("qtd")]
        public int? Qtd { get; set; }

        [Column("create_at")]
        public DateTime? CreateAt { get; set; }

        [Column("update_at")]
        public DateTime? UpdateAt { get; set; }

        public List<Entradas> Entradas { get; set; }

    }

}
