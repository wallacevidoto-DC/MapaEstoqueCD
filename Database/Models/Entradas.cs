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
    }
}
