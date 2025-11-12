namespace MapaEstoqueCD.WebSocketActive.Dto
{
    public class ProdutoWsDto
    {
        public int ProdutoId { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Descricao { get; set; }
    }
}
