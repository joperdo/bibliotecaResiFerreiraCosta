using System.ComponentModel;

namespace gerenciamentoDeBiblioteca.Enums
{
    public enum StatusLivro
    {
        [Description("Disponível")]
        Disponivel = 1,
        [Description("Emprestado")]
        Emprestado = 2,
        [Description("Devolvido")]
        Devovido = 3
    }
}
