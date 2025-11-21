using System.ComponentModel.DataAnnotations;

namespace MapaEstoqueCD.Database.Dto.modal
{
    public class CorrecaoDto
    {
        public string tipo { get; set; } = "CORRECAO";

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O estoqueId deve ser maior que zero.")]
        public int estoqueId { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O usuário deve ser maior que zero.")]
        public int userId { get; set; }

        public string observacao { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório.")]
        public ProdutoSpDto produto { get; set; }
    }
}
