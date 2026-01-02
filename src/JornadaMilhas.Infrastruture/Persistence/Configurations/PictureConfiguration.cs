using JornadaMilhas.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class PictureConfiguration : BaseEntityConfiguration<Picture>
{
    public override void Configure(EntityTypeBuilder<Picture> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(p => p.Destination)
            .WithMany(d => d.Pictures)
            .HasForeignKey(p => p.DestinationId);
        
    }
}