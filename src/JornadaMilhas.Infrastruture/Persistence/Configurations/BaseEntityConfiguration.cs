using JornadaMilhas.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.Property(baseEntity => baseEntity.Id).ValueGeneratedOnAdd();

        builder.Property(b => b.DtCreated)
            .IsRequired();

        builder.Property(b => b.DtUpdated)
            .IsRequired();
    }
}