using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    public class PlaneConfiguration : BaseEntityConfiguration<Plane>
    {
        public override void Configure(EntityTypeBuilder<Plane> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.Company)
                .WithMany(c => c.Planes)
                .HasForeignKey(p => p.CompanyId);

            builder.HasMany(p => p.Flights)
                .WithOne(f => f.Plane)
                .HasForeignKey(f => f.PlaneId);

            builder.Property(x => x.IdentificationCode)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(x => x.Model)
                .HasMaxLength(300)
                .IsRequired();
            
            builder.Property(x => x.InOperation)
                .IsRequired();
            
            builder.Property(x => x.Manufacturer)
                .HasMaxLength(500)
                .IsRequired();
            

            builder.HasOne<BusinessClass>(p => p.BusinessClass)
                .WithOne(b => b.Plane)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<BusinessClass>(b => b.PlaneId);
            
            builder.HasOne<EconomicClass>(p => p.EconomicClass)
                .WithOne(b => b.Plane)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<EconomicClass>(b => b.PlaneId);

        }
    }
}
