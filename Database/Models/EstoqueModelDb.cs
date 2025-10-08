using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("ESTOQUE")]
    public class Estoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("estoqueId")]
        public int EstoqueId { get; set; }

        [Column("enderecoId")]
        public string? EnderecoId { get; set; }

        [Column("produtoId")]
        public int ProdutoId { get; set; }

        [Column("sem_f")]
        public int SemF { get; set; }      

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("data_f")]
        public DateTime DataF { get; set; } = DateTime.Now;

        [Column("data_l")]
        public DateTime DataL { get; set; } = DateTime.Now;

        [Column("lote")]
        public string? Lote { get; set; }

        [Column("obs")]
        public string? Obs { get; set; }

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        [Column("update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.Now;


        public Endereco? Endereco { get; set; }
        public Produtos? Produto { get; set; }    
        public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
}
