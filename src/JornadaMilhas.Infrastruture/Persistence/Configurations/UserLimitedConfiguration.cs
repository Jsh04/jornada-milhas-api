using JornadaMilhas.Common.Entities;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    public class UserLimitedConfiguration : IEntityTypeConfiguration<UserLimited>
    {
        public void Configure(EntityTypeBuilder<UserLimited> builder)
        {
            builder.ToTable("UserLimited");
            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<UserLimited>(userLimited => userLimited.Id);
        }   
    }
}
