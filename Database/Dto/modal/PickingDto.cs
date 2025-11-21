using System.ComponentModel.DataAnnotations;

namespace MapaEstoqueCD.Database.Dto.modal
{
    public class PickingDto
    {
        public string tipo { get; set; } = "PICKING";

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
