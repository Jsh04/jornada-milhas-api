using JornadaMilhas.Core.Entities.Users.UserLimited;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    public class UserLimitedConfiguration : UserConfiguration<UserLimited>
    {
        public override void Configure(EntityTypeBuilder<UserLimited> builder)
        {
            base.Configure(builder);
            
        }   
    }
}
