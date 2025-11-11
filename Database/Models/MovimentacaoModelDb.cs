using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("MOVIMENTACOES")]
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("movimentacaoId")]
        public int MovimentacaoId { get; set; }

        [Column("estoqueId")]
        public int EstoqueId { get; set; }

        [Column("userId")]
        public int UserId { get; set; }

        [Column("produtoId")]
        public int ProdutoId { get; set; }

        [Column("tipo")]
        public string? Tipo { get; set; }

        [Column("data_f")]
        public string DataF { get; set; }

        [Column("sem_f")]
        public int SemF { get; set; }   

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("obs")]
        public string? Obs { get; set; }

        [Column("lote")]
        public string? Lote { get; set; }

        [Column("endereco")]
        public string? Endereco { get; set; }

        [Column("data_l")]
        public DateTime DataL { get; set; }

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        // Relacionamentos
        public Estoque? Estoque { get; set; }
        public User? User { get; set; }
        public Produtos? Produto { get; set; } 
    }
}