using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Entities.Flights;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class DestinationConfiguration : BaseEntityConfiguration<Destination>
{
    public override void Configure(EntityTypeBuilder<Destination> builder)
    {
        base.Configure(builder);
        
        builder.OwnsOne(d => d.Locale, destiny =>
        {
            destiny.Property(l => l.City)
                .HasMaxLength(50)
                .IsRequired();

            destiny.Property(l => l.Country)
                .HasMaxLength(50)
                .IsRequired();

            destiny.Property(l => l.Latitude)
                .HasMaxLength(30)
                .IsRequired();

            destiny.Property(l => l.Longitude)
                .HasMaxLength(30)
                .IsRequired();
        });
        
        builder.Property(d => d.Description)
            .IsRequired();
        
        builder.Property(d => d.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.Subtitle)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasMany(f => f.Flights)
            .WithOne(f => f.Destination)
            .HasForeignKey(f => f.DestinationId);

        builder.HasMany(p => p.Pictures)
            .WithOne(p => p.Destination)
            .HasForeignKey(f => f.DestinationId);
    }
}