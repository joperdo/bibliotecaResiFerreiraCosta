using gerenciamentoDeBiblioteca.Enums;
using System.ComponentModel.DataAnnotations;

namespace gerenciamentoDeBiblioteca.Models
{
    public class EmprestimoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int LivroId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public DateTime DataEmprestimo { get; set; }
        [Required]
        public DateTime DataPrevistaDevolucao { get; set; }
        [Required]
        public bool Entregue { get; set; }
    }
}
