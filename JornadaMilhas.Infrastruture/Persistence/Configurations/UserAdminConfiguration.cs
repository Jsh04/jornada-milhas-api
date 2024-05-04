using JornadaMilhas.Core.Entities.Users.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    internal class UserAdminConfiguration : UserConfiguration<UserAdmin>
    {
        public override void Configure(EntityTypeBuilder<UserAdmin> builder)
        {
            base.Configure(builder);

            builder.Property(user => user.CodeEmployee)
                .HasColumnName("CodeEmployee")
                .HasMaxLength(100)
                .IsRequired();
            
        }
    }
}
