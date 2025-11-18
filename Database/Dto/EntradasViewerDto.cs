namespace MapaEstoqueCD.Database.Dto
{
    public class EntradasViewerDto
    {
        public int EntradaId { get; set; }
        public string Tipo { get; set; }
        public string UserNome { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoCodigo { get; set; }
        public string ProdutoDescricao { get; set; }
        public int? QtdConferida { get; set; }
        public int? QtdEntrada { get; set; }
        public string CifsNome { get; set; }
        public string? Lote { get; set; }
        public string? DataF { get; set; }
        public int? SemF { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
