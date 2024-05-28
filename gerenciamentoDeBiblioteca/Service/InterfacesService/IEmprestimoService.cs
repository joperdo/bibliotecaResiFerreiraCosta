using gerenciamentoDeBiblioteca.Dtos;
using gerenciamentoDeBiblioteca.Models;

namespace gerenciamentoDeBiblioteca.Service.InterfacesService
{
    public interface IEmprestimoService
    {
        Task<EmprestimoDTO> BuscarPorId(int id);
        Task<EmprestimoDTO> Adicionar(PostEmprestimoDTO postEmprestimoDTO);
        Task<EmprestimoDTO> Atualizar(EmprestimoDTO emprestimoDTO, int id);
        Task<EmprestimoDTO> Apagar(int id);
        Task<bool> VerificaDisponibilidadeAsync(int idLivro);
    }
}
