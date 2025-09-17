using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Admins;
using JornadaMilhas.Core.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Users;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    public class AdminConfiguration : BaseEntityConfiguration<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Admin));

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Admin>(a => a.Id);

            builder.HasOne<Company>(a => a.Company)
                .WithMany(c => c.Admins)
                .HasForeignKey(a => a.CompanyId);

        }
    }
}
