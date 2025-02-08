using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Planes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class EconomicClassConfiguration : ClassConfiguration<EconomicClass>
{
    public override void Configure(EntityTypeBuilder<EconomicClass> builder)
    {
        base.Configure(builder);
        
        builder.HasOne<Plane>()
            .WithOne(x => x.EconomicClass)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey<Plane>(p => p.EconomicClassId);
    }
}