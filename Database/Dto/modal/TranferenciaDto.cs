namespace MapaEstoqueCD.Database.Dto.modal
{
    public class TranferenciaDto
    {
        public string tipo = "TRANSFERENCIA";
        public string rua { get; set; }
        public string bloco { get; set; }
        public string apt { get; set; }
        public string endOld { get; set; }
        public int  estoqueID { get; set; }

        public string observacao { get; set; }
        public DateTime dataEntrada { get; set; }

        public int userId { get; set; }
        public ProdutoSpDto produto { get; set; }
    }
}
