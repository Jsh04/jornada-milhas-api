using JornadaMilhas.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Common.Configuration;

public class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<BaseEntity> where TBase : BaseEntity
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.HasKey(b => b.Id);
    }
}