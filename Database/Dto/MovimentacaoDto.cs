namespace MapaEstoqueCD.Database.Dto
{
    public class MovimentacaoDto
    {
        public int movimentacaoId { get; set; }
        public int? estoqueId { get; set; }
        public string? estoque { get; set; }
        public string? usuarioNome { get; set; }
        public string? endereco { get; set; }
        public string? produtoCodigo { get; set; }
        public string? produtoDescricao { get; set; }

        public string? tipo { get; set; }
        public string dataF { get; set; }
        public int? semF { get; set; }
        public int quantidade { get; set; }
        public string? lote { get; set; }
        public string? obs { get; set; }
        public DateTime createAt { get; set; }
    }
}
