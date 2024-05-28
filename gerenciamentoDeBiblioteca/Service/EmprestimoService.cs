using gerenciamentoDeBiblioteca.Repositorios.Interfaces;
using AutoMapper;
using gerenciamentoDeBiblioteca.Dtos;
using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Service.InterfacesService;
using gerenciamentoDeBiblioteca.Repositorios;

namespace gerenciamentoDeBiblioteca.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepositorio _repositorio;
        private readonly IMapper  _mapper;

        public EmprestimoService(IEmprestimoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<EmprestimoDTO> BuscarPorId(int id)
        {
            var emprestimo = await _repositorio.BuscarPorId(id);
            return _mapper.Map<EmprestimoDTO>(emprestimo);
        }

        public async Task<EmprestimoDTO> Adicionar(PostEmprestimoDTO postEmprestimoDTO)
        {
            var emprestimo = _mapper.Map<EmprestimoModel>(postEmprestimoDTO);
            var emprestimoIncluido = await _repositorio.Adicionar(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoIncluido);
        }

        public async Task<EmprestimoDTO> Apagar(int id)
        {
            var emprestimoExcluido = await _repositorio.Apagar(id);
            return _mapper.Map<EmprestimoDTO>(emprestimoExcluido);
        }

        public async Task<EmprestimoDTO> Atualizar(EmprestimoDTO emprestimoDTO)
        {
            var emprestimo = _mapper.Map<EmprestimoModel>(emprestimoDTO);
            var emprestimoAlterado = await _repositorio.Atualizar(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoAlterado);
        }

        public Task<EmprestimoDTO> Atualizar(EmprestimoDTO emprestimoDTO, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerificaDisponibilidadeAsync(int idLivro)
        {
            return await _repositorio.VerificaDisponibilidadeAsync(idLivro);
        }
    }
}
