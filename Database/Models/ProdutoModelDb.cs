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

        [Column("cod")]
        [Required]
        public string Cod { get; set; } = null!;

        [Column("produto")]
        public byte[]? Produto { get; set; } = null;

        [Column("descricao")]
        public string? Descricao { get; set; } = string.Empty;

        [Column("ncm")]
        public string? Ncm { get; set; } = string.Empty;

        [Column("ipi")]
        public double? Ipi { get; set; } = 0;

        [Column("pis")]
        public double? Pis { get; set; } = 0;

        [Column("cofins")]
        public double? Cofins { get; set; } = 0;

        [Column("shelf_life")]
        public  string? ShelfLife { get; set; } = string.Empty;

        [Column("codigo_barras_ean13")]
        public string? CodigoBarrasEan13 { get; set; } = string.Empty;

        [Column("c_cm_unit")]
        public double? CcmUnit { get; set; } = 0;

        [Column("l_cm_unit")]
        public double? LcmUnit { get; set; } = 0;

        [Column("d_cm_unit")]
        public double? DcmUnit { get; set; } = 0;

        [Column("h_cm_unit")]
        public double? HcmUnit { get; set; } = 0;

        [Column("peso_liquido_unit")]
        public double? PesoLiquidoUnit { get; set; } = 0;

        [Column("peso_bruto_unit")]
        public double? PesoBrutoUnit { get; set; } = 0;

        [Column("codigo_barras_dun13")]
        public string? CodigoBarrasDun13 { get; set; } = string.Empty;

        [Column("qtd_unit")]
        public int? QtdUnit { get; set; } = 0;

        [Column("c_cm_caixa")]
        public double? CcmCaixa { get; set; } = 0;

        [Column("l_cm_caixa")]
        public double? LcmCaixa { get; set; } = 0;

        [Column("h_cm_caixa")]
        public double? HcmCaixa { get; set; } = 0;

        [Column("peso_liquido_caixa")]
        public double? PesoLiquidoCaixa { get; set; } = 0;

        [Column("peso_bruto_caixa")]
        public double? PesoBrutoCaixa { get; set; } = 0;

        [Column("codigo_barras_dun14")]
        public string? CodigoBarrasDun14 { get; set; } = string.Empty;

        [Column("qtd_caixa")]
        public int? QtdCaixa { get; set; } = 0;

        [Column("c_cm_palet")]
        public double? CcmPalet { get; set; } = 0;

        [Column("l_cm_palet")]
        public double? LcmPalet { get; set; } = 0;

        [Column("h_cm_palet")]
        public double? HcmPalet { get; set; } = 0;

        [Column("peso_liquido_palet")]
        public double? PesoLiquidoPalet { get; set; } = 0;

        [Column("peso_bruto_palet")]
        public double? PesoBrutoPalet { get; set; } = 0;

        [Column("cxs_por_lastro")]
        public int? CxsPorLastro { get; set; } = 0;

        [Column("emp_cxs")]
        public int? EmpCxs { get; set; } = 0;

        [Column("cxs_por_palet")]
        public int? CxsPorPalet { get; set; } = 0;

        [Column("update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
        public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
}
