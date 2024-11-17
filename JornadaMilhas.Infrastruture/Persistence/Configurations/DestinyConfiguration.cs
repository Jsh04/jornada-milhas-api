using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Destinies;
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
        }
    }
}
