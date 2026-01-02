using JornadaMilhas.Common.Entities;
using JornadaMilhas.Core.Entities.Users.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    internal class UserAdminConfiguration : IEntityTypeConfiguration<UserAdmin>
    {
        public void Configure(EntityTypeBuilder<UserAdmin> builder)
        {
            builder.ToTable("UserAdmin");
            builder.Property(user => user.CodeEmployee)
                .HasColumnName("CodeEmployee")
                .HasMaxLength(100)
            .IsRequired();

            builder
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<UserAdmin>(a => a.Id);
        }
    }
}
