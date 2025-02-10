using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Admins;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Planes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class CompanyConfiguration : BaseEntityConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany<Plane>()
            .WithOne(p => p.Company)
            .HasForeignKey(p => p.CompanyId);

        builder.HasMany<Admin>()
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);


        builder.Property(c => c.DtFoundation)
            .IsRequired();
    }
}