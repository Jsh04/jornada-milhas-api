using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class FlightConfiguration : BaseEntityConfiguration<Flight>
{
    public override void Configure(EntityTypeBuilder<Flight> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.Destiny, destiny =>
        {
            destiny.Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

            destiny.Property(x => x.Country)
            .HasMaxLength(50)
            .IsRequired();

            destiny.Property(x => x.Latitude)
            .HasMaxLength(30)
            .IsRequired();

            destiny.Property(x => x.Longitude)
            .HasMaxLength(30)
            .IsRequired();

        });

        builder.OwnsOne(x => x.Source, source =>
        {
            source.Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

            source.Property(x => x.Country)
            .HasMaxLength(50)
            .IsRequired();

            source.Property(x => x.Latitude)
            .HasMaxLength(30)
            .IsRequired();
            
            source.Property(x => x.Longitude)
            .HasMaxLength(30)
            .IsRequired();

        });

        builder.HasOne<Plane>()
            .WithMany(x => x.Flights)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(x => x.PlaneId);
        
        builder.HasMany(f => f.Passages)
            .WithOne(p => p.Flight)
            .HasForeignKey(p => p.FlightId);

        builder.HasMany(f => f.Pictures)
            .WithOne(p => p.Flight)
            .HasForeignKey(p => p.FlightId);

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.BasePrice)
            .HasPrecision(10,2)
            .IsRequired();
    }
}