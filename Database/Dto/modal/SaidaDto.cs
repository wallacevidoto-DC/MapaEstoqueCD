using System.ComponentModel.DataAnnotations;

namespace MapaEstoqueCD.Database.Dto.modal
{
    public class SaidaDto
    {
        public string tipo { get; set; } = "SAIDA";

        public string observacao { get; set; }

        [Required(ErrorMessage = "A quantidade retirada é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade retirada deve ser maior que zero.")]
        public int qtdRetirada { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O estoque deve ser maior que zero.")]
        public int estoqueId { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O usuário deve ser maior que zero.")]
        public int userId { get; set; }
    }
}
