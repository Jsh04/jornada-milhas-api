using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Orders;
using JornadaMilhas.Core.Entities.Passages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class OrderConfiguration : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.HasMany(o => o.Passages)
            .WithOne(passage => passage.Order)
            .HasForeignKey(passage => passage.OrderId);
        
        builder.Property(o => o.TotalValue)
            .HasPrecision(10, 2)
            .IsRequired();
        
        builder.HasOne<Customer>(o => o.Customer)
            .WithMany(customer => customer.Orders)
            .HasForeignKey(order => order.CustomerId);
    }
}