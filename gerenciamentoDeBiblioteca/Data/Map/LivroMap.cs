using gerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gerenciamentoDeBiblioteca.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<LivroModel>
    {
        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Autor).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Categoria).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
