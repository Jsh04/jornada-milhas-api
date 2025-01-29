using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
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

            builder.HasMany<Flight>()
                .WithOne(f => f.Plane)
                .HasForeignKey(f => f.PlaneId);

            builder.Property(x => x.IdentificationCode)
                .HasMaxLength(255)
                .IsRequired();
                
        }
    }
}
