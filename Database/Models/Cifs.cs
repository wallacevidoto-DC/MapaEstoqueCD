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

        [Column("cifCod")]
        public string CifCod { get; set; }

        [Column("create_at")]
        public DateTime? CreateAt { get; set; }

        [Column("update_at")]
        public DateTime? UpdateAt { get; set; }

        public List<Entradas> Entradas { get; set; }

    }

}
