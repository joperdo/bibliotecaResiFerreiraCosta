using gerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentoDeBiblioteca.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<EmprestimoModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LivroId).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.DataEmprestimo).IsRequired();
            builder.Property(x => x.DataPrevistaDevolucao).IsRequired();
            builder.Property(x => x.Entregue).IsRequired();
  
        }
    }
}
