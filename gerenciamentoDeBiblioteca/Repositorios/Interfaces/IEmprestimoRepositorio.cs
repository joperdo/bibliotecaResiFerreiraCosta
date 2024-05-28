using gerenciamentoDeBiblioteca.Models;

namespace gerenciamentoDeBiblioteca.Repositorios.Interfaces
{
    public interface IEmprestimoRepositorio
    {
        Task<List<EmprestimoModel>> BuscarTodosEmprestimos();
        Task <EmprestimoModel> BuscarPorId(int id);
        Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo);
        Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo);
        Task<bool> Apagar(int id);
        Task<bool> VerificaDisponibilidadeAsync(int idLivro);

    }
}
