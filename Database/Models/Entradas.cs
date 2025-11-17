using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("ENTRADAS")]
    public class Entradas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("entradaId")]
        public int EntradaId { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("userId")]
        public int UserId { get; set; }

        [Column("produtoId")]
        public int? ProdutoId { get; set; }
        public Produtos Produto { get; set; }

        [Column("qtd_conferida")]
        public int? QtdConferida { get; set; }

        [Column("qtd_entrada")]
        public int? QtdEntrada { get; set; }

        [Column("cifsId")]
        public int? CifsId { get; set; }

        public Cifs Cifs { get; set; }

        [Column("create_at")]
        public DateTime? CreateAt { get; set; }

        [Column("update_at")]
        public DateTime? UpdateAt { get; set; }

        public User? User { get; set; }
    }
}
