namespace MapaEstoqueCD.Database.Dto.modal
{
    public class EntradaDto
    {
        public string tipo = "ENTRADA";
        public string rua { get; set; }
        public string bloco { get; set; }
        public string apt { get; set; }

        public int? entradaId { get; set; }
        public DateTime dataEntrada { get; set; }

        public string observacao { get; set; }


        public int userId { get; set; }
        public List<ProdutoSpDto> produtos { get; set; }
    }
}
