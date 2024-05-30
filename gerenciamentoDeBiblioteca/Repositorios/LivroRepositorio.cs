using gerenciamentoDeBiblioteca.Data;
using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerenciamentoDeBiblioteca.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly SistemaLivrosDBContex _dbContext;

        public LivroRepositorio(SistemaLivrosDBContex sistemaLivrosDBContex)
        {
            _dbContext = sistemaLivrosDBContex;
        }

        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbContext.Livros
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LivroModel>> BuscarTodosLivros()
        {
            return await _dbContext.Livros
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
            return livro;
        }

        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                // Tratar o caso em que o livro não é encontrado
            }
            livroPorId.Nome = livro.Nome;
            livroPorId.Autor = livro.Autor;
            livroPorId.Categoria = livro.Categoria;
            livroPorId.Valor = livro.Valor;
            livroPorId.Status = livro.Status;
            livroPorId.UsuarioId = livro.UsuarioId;
            _dbContext.Livros.Update(livroPorId);
            await _dbContext.SaveChangesAsync();
            return livroPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                // Tratar o caso em que o livro não é encontrado
            }
            _dbContext.Livros.Remove(livroPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<LivroModel>> PesquisarPorNome(string nome)
        {
            return await _dbContext.Livros
                .Where(x => x.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<List<LivroModel>> PesquisarPorAutor(string autor)
        {
            return await _dbContext.Livros
                .Where(x => x.Autor.Contains(autor))
                .ToListAsync();
        }

        public async Task<List<LivroModel>> PesquisarPorCategoria(string categoria)
        {
            return await _dbContext.Livros
                .Where(x => x.Categoria.Contains(categoria))
                .ToListAsync();
        }

    }
}
