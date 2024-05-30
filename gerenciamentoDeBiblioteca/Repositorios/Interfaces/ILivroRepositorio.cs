using gerenciamentoDeBiblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gerenciamentoDeBiblioteca.Repositorios.Interfaces
{
    public interface ILivroRepositorio
    {
        Task<List<LivroModel>> BuscarTodosLivros();
        Task<LivroModel> BuscarPorId(int id);
        Task<LivroModel> Adicionar(LivroModel livro);
        Task<LivroModel> Atualizar(LivroModel livro, int id);
        Task<bool> Apagar(int id);
        Task<List<LivroModel>> PesquisarPorNome(string nome);
        Task<List<LivroModel>> PesquisarPorAutor(string autor);
        Task<List<LivroModel>> PesquisarPorCategoria(string categoria);
    }
}
