using gerenciamentoDeBiblioteca.Enums;
using gerenciamentoDeBiblioteca.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gerenciamentoDeBiblioteca.Dtos
{
    public class PostEmprestimoDTO
    {
        [Required(ErrorMessage= "O id do livro é obrigatório")]
        [Range(1, int.MaxValue)]
        public int LivroId { get; set; }
        [Required (ErrorMessage = "O id do usuario é obrigatório")]
        [Range(1, int.MaxValue)]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "A data de devolução é obrigatória")]
        public DateTime DataPrevistaDevolucao { get; set; }
        [JsonIgnore]
        public DateTime DataEmprestimo { get; set; }
        [JsonIgnore]
        public bool Entregue { get; set; }
        [NotMapped]
        public int[] idsLivros { get; set; }
    }
}
