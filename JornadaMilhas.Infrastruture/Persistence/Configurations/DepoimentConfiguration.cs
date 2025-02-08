using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Depoiments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class DepoimentConfiguration : BaseEntityConfiguration<Depoiment>
{
    public override void Configure(EntityTypeBuilder<Depoiment> builder)
    {
        base.Configure(builder);

        builder.HasOne<Customer>()
            .WithMany(c => c.Depoiments)
            .HasForeignKey(d => d.CustomerId);

    }
}