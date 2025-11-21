using System.ComponentModel.DataAnnotations;

namespace MapaEstoqueCD.Database.Dto.modal
{
    public class TranferenciaDto
    {
        public string tipo { get; set; } = "TRANSFERENCIA";

        [Required(ErrorMessage = "A rua é obrigatória.")]
        public string rua { get; set; }

        [Required(ErrorMessage = "O bloco é obrigatório.")]
        public string bloco { get; set; }

        [Required(ErrorMessage = "O apartamento é obrigatório.")]
        public string apt { get; set; }

        [Required(ErrorMessage = "O endereço antigo é obrigatório.")]
        public string endOld { get; set; }

        [Required(ErrorMessage = "O id do estoque é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O estoque deve ser maior que zero.")]
        public int estoqueID { get; set; }

        public string observacao { get; set; }

        [Required(ErrorMessage = "A data de entrada é obrigatória.")]
        public DateTime dataEntrada { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O usuário deve ser maior que zero.")]
        public int userId { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório.")]
        public ProdutoSpDto produto { get; set; }
    }
}
