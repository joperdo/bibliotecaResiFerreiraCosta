using gerenciamentoDeBiblioteca.Enums;
using gerenciamentoDeBiblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace gerenciamentoDeBiblioteca.Dtos
{
    public class EmprestimoDTO
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
