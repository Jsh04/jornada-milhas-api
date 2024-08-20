using JornadaMilhas.Common.Persistence.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Common.Persistence.Configuration
{
    public class QueueGenericConfiguration : IEntityTypeConfiguration<QueueGeneric>
    {
        public void Configure(EntityTypeBuilder<QueueGeneric> builder)
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
}
