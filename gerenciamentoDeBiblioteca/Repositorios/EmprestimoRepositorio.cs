using gerenciamentoDeBiblioteca.Data;
using gerenciamentoDeBiblioteca.Enums;
using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace gerenciamentoDeBiblioteca.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly SistemaLivrosDBContex _dbContext;
        public EmprestimoRepositorio(SistemaLivrosDBContex sistemaLivrosDBContex) 
        {
            _dbContext = sistemaLivrosDBContex;
        }
        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            return await _dbContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo)
        {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();

            return emprestimo;
        }
        public async Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);

            if (emprestimoPorId == null) 
            {
                throw new Exception($"Emprestimo para o ID: {id} não foi encontrado");
            }
            emprestimoPorId.UsuarioId = emprestimo.UsuarioId;
            emprestimoPorId.LivroId = emprestimo.LivroId;
            emprestimoPorId.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoPorId.DataPrevistaDevolucao = emprestimo.DataPrevistaDevolucao;
            emprestimoPorId.Entregue = emprestimo.Entregue;

            _dbContext.Emprestimos.Update(emprestimoPorId);
            await _dbContext.SaveChangesAsync();

            return emprestimoPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);

            if (emprestimoPorId == null)
            {
                throw new Exception($"Emprestimo para o ID: {id} não foi encontrado");
            }
            _dbContext.Emprestimos.Remove(emprestimoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<List<EmprestimoModel>> BuscarTodosEmprestimos()
        {
            throw new NotImplementedException();
        }

        public Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerificaDisponibilidadeAsync(int idLivro)
        {
            var existeEmprestimo = await _dbContext.Emprestimos.
                Where(x => x.LivroId == idLivro && x.Entregue == false).AnyAsync();

            return !existeEmprestimo;
        }

        
    }
}
