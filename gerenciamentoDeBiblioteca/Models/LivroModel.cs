using gerenciamentoDeBiblioteca.Enums;

namespace gerenciamentoDeBiblioteca.Models
{
    public class LivroModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Autor { get; set; }

        public string? Categoria { get; set; }

        public float Valor { get; set; }

        public StatusLivro Status { get; set; }
    }
}
