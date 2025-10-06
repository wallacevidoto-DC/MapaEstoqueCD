using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    [Table("ESTOQUE")]
    public class Estoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstoqueId { get; set; }

        public string? EnderecoId { get; set; }

        public int ProdutoId { get; set; }

        public int Fardo { get; set; }
        public int Quantidade { get; set; }
        public int Quebra { get; set; }

        [Column("date_in")]
        public DateTime DateIn { get; set; } = DateTime.Now;

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        [Column("update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public string? Obs { get; set; }


        public Endereco? Endereco { get; set; }
        public Produtos? Produtos { get; set; }
        public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
}
