using JornadaMilhas.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Common.Configuration;

public abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.DtCreated)
            .IsRequired();

        builder.Property(b => b.DtUpdated)
            .IsRequired();
    }
}