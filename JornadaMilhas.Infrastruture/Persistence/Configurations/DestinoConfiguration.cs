using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities.Destinys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    internal class DestinoConfiguration : IEntityTypeConfiguration<Destiny>
    {
        public void Configure(EntityTypeBuilder<Destiny> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasMany(u => u.Imagens)
                .WithOne(d => d.Destino)
                .HasForeignKey(d => d.IdDestino)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
