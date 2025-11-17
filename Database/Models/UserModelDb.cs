using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public required string Name { get; set; }
        public string? Password { get; set; }

        public UserRole? Role { get; set; }

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
        public ICollection<Entradas> Entradas { get; set; } = new List<Entradas>();
    }

    public enum UserRole
    {
        DEV,
        ADMIN,
        USER,
    }
}
