using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Admins;
using JornadaMilhas.Core.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities.Companies;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    public class AdminConfiguration : UserConfiguration<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Admin));

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Admin>(a => a.Id);

            builder.HasOne<Company>()
                .WithMany(c => c.Admins)
                .HasForeignKey(a => a.CompanyId);

        }
    }
}
