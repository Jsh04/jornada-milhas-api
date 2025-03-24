using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Orders;
using JornadaMilhas.Core.Entities.Passages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class PassageConfiguration : BaseEntityConfiguration<Passage>
{
    public override void Configure(EntityTypeBuilder<Passage> builder)
    {
        base.Configure(builder);
        
        builder.HasOne<Order>(p => p.Order)
            .WithMany(o => o.Passages)
            .HasForeignKey(passage => passage.OrderId);

        builder.Property(p => p.Value)
            .HasPrecision(10, 2)
            .IsRequired();
    }
}