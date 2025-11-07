namespace MapaEstoqueCD.Database.Dto.Ws
{
    public class ProdutoWsDto
    {
        public string? codigo { get; set; } = string.Empty;
        public string? descricao { get; set; } = string.Empty;
    }
    public class EstoqueWsDto
    {
        public int estoqueId { get; set; }
        public string? enderecoId { get; set; }
        public int produtoId { get; set; }
        public int semF { get; set; }
        public int quantidade { get; set; }
        public string dataF { get; set; }
        public DateTime dataL { get; set; }
        public string? lote { get; set; }
        public string? obs { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
        public ProdutoWsDto? produto { get; set; }
    }
}
