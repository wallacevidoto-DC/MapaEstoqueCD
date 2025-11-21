using System.ComponentModel.DataAnnotations;

namespace MapaEstoqueCD.Database.Dto.modal
{
    public class EntradaDto
    {
        public string tipo { get; set; } = "ENTRADA";

        [Required(ErrorMessage = "A rua é obrigatória.")]
        public string rua { get; set; }

        [Required(ErrorMessage = "O bloco é obrigatório.")]
        public string bloco { get; set; }

        [Required(ErrorMessage = "O apartamento é obrigatório.")]
        public string apt { get; set; }

        public int? entradaId { get; set; }

        [Required(ErrorMessage = "A data de entrada é obrigatória.")]
        public DateTime dataEntrada { get; set; }

        public string observacao { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O usuário deve ser maior que zero.")]
        public int userId { get; set; }

        [Required(ErrorMessage = "A lista de produtos é obrigatória.")]
        [MinLength(1, ErrorMessage = "Informe pelo menos um produto.")]
        public List<ProdutoSpDto> produtos { get; set; }
    }
}
