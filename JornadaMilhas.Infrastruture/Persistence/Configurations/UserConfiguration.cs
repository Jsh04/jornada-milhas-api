using JornadaMilhas.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(entity => entity.Id);

        builder.OwnsOne(user => user.Cpf, cpf =>
        {
            cpf.Property(c => c.Number)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

            cpf.HasIndex(c => c.Number)
                .IsUnique();
        });

        builder.OwnsOne(user => user.DtBirth, dtbirth =>
        {
            dtbirth.Property(dtBirth => dtBirth.Date)
                .HasColumnType("date")
                .IsRequired();

        });
    }
}