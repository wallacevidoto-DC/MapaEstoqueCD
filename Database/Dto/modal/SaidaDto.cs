namespace MapaEstoqueCD.Database.Dto.modal
{
    public class SaidaDto
    {
        public string tipo = "SAIDA";

        public string observacao { get; set; }
        public int qtdRetirada { get; set; }
        public int estoqueId { get; set; }
        public int userId { get; set; }

    }
}
