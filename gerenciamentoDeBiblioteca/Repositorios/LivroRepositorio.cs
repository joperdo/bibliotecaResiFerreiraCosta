using gerenciamentoDeBiblioteca.Data;
using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            
            if(livroPorId == null)
            {
                throw new Exception($"Livro para o ID: {id} não foi encontrado no banco de dados.");
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
                throw new Exception($"Livro para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Livros.Remove(livroPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public Task<LivroModel> Adicionar(object livroModel)
        {
            throw new NotImplementedException();
        }
    }
}
