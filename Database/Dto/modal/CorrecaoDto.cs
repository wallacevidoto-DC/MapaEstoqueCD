namespace MapaEstoqueCD.Database.Dto.modal
{
    public class CorrecaoDto
    {
        public string tipo = "CORRECAO";
        public int estoqueId { get; set; }
        public int userId { get; set; }
        public string observacao { get; set; }
        public ProdutoSpDto produto { get; set; }
    }
}
