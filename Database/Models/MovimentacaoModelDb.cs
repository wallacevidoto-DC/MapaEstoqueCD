using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("MOVIMENTACOES")]
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovimentacaoId { get; set; }

        public int EstoqueId { get; set; }
        public int UserId { get; set; }
        public int ProdutoId { get; set; }

        public string? Tipo { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int Fardo { get; set; }
        public int Quantidade { get; set; }
        public int Quebra { get; set; }
        public string? Obs { get; set; }

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;


        public Estoque? Estoque { get; set; }
        public User? User { get; set; }
        public Produtos? Produtos { get; set; }
    }
}
