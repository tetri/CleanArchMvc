using CleanArchMvc.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Sigla).HasMaxLength(3).IsRequired();

            builder.HasData(
                new Pais(1, "Brasil", "BR"),
                new Pais(2, "Paraguai", "PY"),
                new Pais(3, "Argentina", "AR")
            );
        }
    }
}
