using JornadaMilhas.Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class ClassConfiguration<TClass> : BaseEntityConfiguration<TClass> where TClass : Class
{
    public override void Configure(EntityTypeBuilder<TClass> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.ReservedSeats)
            .HasDefaultValue(0)
            .IsRequired();
        
        builder.Property(x => x.TotalSeats)
            .IsRequired();
        
        builder.Property(x => x.PriceSeat)
            .HasPrecision(10, 2)
            .IsRequired();
    }
}