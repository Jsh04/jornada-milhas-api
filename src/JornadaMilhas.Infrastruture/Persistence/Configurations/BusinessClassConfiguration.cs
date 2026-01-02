using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Planes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class BusinessClassConfiguration : ClassConfiguration<BusinessClass>
{
    public override void Configure(EntityTypeBuilder<BusinessClass> builder)
    {
        base.Configure(builder);
        
        builder.HasOne<Plane>(p => p.Plane)
            .WithOne(x => x.BusinessClass)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey<Plane>(p => p.BusinessClassId);
    }
}