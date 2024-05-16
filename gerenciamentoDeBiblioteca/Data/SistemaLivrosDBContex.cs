using gerenciamentoDeBiblioteca.Data.Map;
using gerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentoDeBiblioteca.Data
{
    public class SistemaLivrosDBContex : DbContext
    {

        public SistemaLivrosDBContex(DbContextOptions<SistemaLivrosDBContex> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LivroModel> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LivroMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
