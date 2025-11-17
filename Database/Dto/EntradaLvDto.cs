using MapaEstoqueCD.WebSocketActive.Dto;

namespace MapaEstoqueCD.Database.Dto
{
    public class EntradaLvDto
    {
        public string tipo = "CONFERÊNCIA";
        public int qtd_conferida {  get; set; }
        public int userId { get; set; }
        public ProdutoWsDto produto { get; set; }
    }
}
