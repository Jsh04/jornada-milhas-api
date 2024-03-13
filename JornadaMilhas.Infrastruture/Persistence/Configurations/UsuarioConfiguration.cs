
using JornadaMilhas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(entity => entity.Id);

        builder.HasMany(u => u.Depoimentos)
            .WithOne(l => l.Usuario)
            .HasForeignKey(d => d.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);
    }
}