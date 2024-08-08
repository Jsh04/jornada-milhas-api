using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Destinys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    internal class DestinoConfiguration : BaseEntityConfiguration<Destiny>
    {
        public void Configure(EntityTypeBuilder<Destiny> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.DescriptionPortuguese)
                .IsRequired()
                .HasMaxLength(1500);

            builder.Property(d => d.DescriptionEnglish)
                .IsRequired()
                .HasMaxLength(1500);

            builder.Property(d => d.Subtitle)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(d => d.Price)
                .HasPrecision(18, 2)
                .IsRequired();


            builder.HasMany(u => u.Imagens)
                .WithOne(d => d.Destino)
                .HasForeignKey(d => d.IdDestino)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
