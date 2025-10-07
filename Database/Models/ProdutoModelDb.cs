using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapaEstoqueCD.Database.Models
{

    [Table("PRODUTOS")]
    public class Produtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("produtoId")]
        public int ProdutoId { get; set; }

        [Required]
        [Column("codigo")]
        public string Codigo { get; set; } = null!;

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("produto")]
        public string? Produto { get; set; }

        [Column("ncm")]
        public string? Ncm { get; set; }

        [Column("ipi")]
        public decimal? Ipi { get; set; }

        [Column("pis")]
        public decimal? Pis { get; set; }

        [Column("cofins")]
        public decimal? Cofins { get; set; }

        [Column("shelf_life")]
        public string? ShelfLife { get; set; }

        // Unidade
        [Column("u_codigo_barras")]
        public string? UCodigoBarras { get; set; }

        [Column("u_c")]
        public double? UC { get; set; }

        [Column("u_l")]
        public double? UL { get; set; }

        [Column("u_d")]
        public double? UD { get; set; }

        [Column("u_h")]
        public double? UH { get; set; }

        [Column("u_peso_liquido")]
        public double? UPesoLiquido { get; set; }

        [Column("u_peso_bruto")]
        public double? UPesoBruto { get; set; }

        // Display
        [Column("d_codigo_barras")]
        public string? DCodigoBarras { get; set; }

        [Column("d_qtd")]
        public int? DQtd { get; set; }

        [Column("d_c")]
        public double? DC { get; set; }

        [Column("d_l")]
        public double? DL { get; set; }        

        [Column("d_h")]
        public double? DH { get; set; }

        [Column("d_peso_liquido")]
        public double? DPesoLiquido { get; set; }

        [Column("d_peso_bruto")]
        public double? DPesoBruto { get; set; }

        // Caixa
        [Column("c_codigo_barras")]
        public string? CCodigoBarras { get; set; }

        [Column("c_qtd")]
        public int? CQtd { get; set; }

        [Column("c_c")]
        public double? CC { get; set; }

        [Column("c_l")]
        public double? CL { get; set; }

        [Column("c_h")]
        public double? CH { get; set; }

        [Column("c_peso_liquido")]
        public double? CPesoLiquido { get; set; }

        [Column("c_peso_bruto")]
        public double? CPesoBruto { get; set; }

        // Paletização
        [Column("p_cx_lastro")]
        public int? PCxLastro { get; set; }

        [Column("p_emp_cx")]
        public int? PEmpCx { get; set; }

        [Column("p_cx_palete")]
        public int? PCxPalete { get; set; }

        [Column("update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
        public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
    
}
