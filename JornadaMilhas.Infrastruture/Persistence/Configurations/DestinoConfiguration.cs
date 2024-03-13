using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    internal class DestinoConfiguration : IEntityTypeConfiguration<Destino>
    {
        public void Configure(EntityTypeBuilder<Destino> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasMany(u => u.Imagens)
                .WithOne(d => d.Destino)
                .HasForeignKey(d => d.IdDestino)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
