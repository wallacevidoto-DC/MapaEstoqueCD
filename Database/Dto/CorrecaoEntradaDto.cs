using System.ComponentModel.DataAnnotations;

namespace MapaEstoqueCD.Database.Dto
{
    public class CorrecaoEntradaDto
    {
        [Required(ErrorMessage = "O tipo é obrigatório.")]
        public string tipo { get; set; } = "CR. CONFERÊNCIA";

        [Required(ErrorMessage = "O ID da conferência é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID da conferência deve ser maior que zero.")]
        public int conferenciaId { get; set; }

        [Required(ErrorMessage = "A quantidade conferida é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade conferida deve ser maior que zero.")]
        public int qtd_conferida { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O usuário deve ser maior que zero.")]
        public int userId { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public string dataf { get; set; }

        [Required(ErrorMessage = "O campo semf é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O valor de semf deve ser maior ou igual a zero.")]
        public int semf { get; set; }

        [Required(ErrorMessage = "O lote é obrigatório.")]
        public string lote { get; set; }
    }
}
