using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.ValueObjects.Locales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

internal class DestinoConfiguration : BaseEntityConfiguration<Locale>
{
    public void Configure(EntityTypeBuilder<Locale> builder)
    {
        base.Configure(builder);

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

        builder.OwnsMany(d => d.Pictures, pictureBuilder =>
        {
            pictureBuilder.HasKey(p => p.Id);
            pictureBuilder.Property(p => p.PathS3).IsRequired();
            pictureBuilder.Property(p => p.DestinyId).IsRequired();
        });
    }
}