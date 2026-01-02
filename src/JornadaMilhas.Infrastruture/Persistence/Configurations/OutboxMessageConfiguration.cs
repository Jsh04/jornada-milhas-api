using JornadaMilhas.Infrastruture.Message.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(p => p.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Error)
            .HasMaxLength(500);

        builder.Property(b => b.TimeCreated)
            .IsRequired();

        builder.Property(b => b.ProcessedAt);
    }
}