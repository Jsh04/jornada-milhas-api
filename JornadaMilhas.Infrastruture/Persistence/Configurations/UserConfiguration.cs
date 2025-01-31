﻿using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class UserConfiguration<TUser> : BaseEntityConfiguration<TUser> where TUser : User
{
    public override void Configure(EntityTypeBuilder<TUser> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users");

        builder.Property(user => user.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(user => user.Password)
            .IsRequired();

        builder.Property(user => user.Picture)
            .HasMaxLength(1000);

        builder.Property(user => user.Genre)
            .HasMaxLength(1)
            .IsRequired();

        builder.OwnsOne(user => user.Cpf, cpf =>
        {
            cpf.Property(c => c.Number)
                .HasMaxLength(11)
                .IsRequired();

            cpf.HasIndex(c => c.Number)
                .IsUnique();
        });

        builder.OwnsOne(user => user.Phone, phone =>
        {
            phone.Property(p => p.Number)
                .HasMaxLength(11)
                .IsRequired();
        });

        builder.OwnsOne(user => user.Email, email =>
        {
            email.Property(e => e.Address)
                .HasMaxLength(100)
                .IsRequired();

            email.HasIndex(e => e.Address)
                .IsUnique();
        });

        builder.OwnsOne(user => user.Address, valueAddress =>
        {
            valueAddress.Property(address => address.Street)
                .HasMaxLength(150);

            valueAddress.Property(address => address.State)
                .HasMaxLength(2)
                .IsRequired();

            valueAddress.Property(address => address.City)
                .HasMaxLength(50)
                .IsRequired();

            valueAddress.Property(address => address.Cep)
                .HasMaxLength(8);

            valueAddress.Property(address => address.District)
                .HasMaxLength(50);
        });

        builder.OwnsOne(user => user.ConfirmEmail, confirmEmail =>
        {
            confirmEmail.Property(ce => ce.Address)
                .HasMaxLength(100)
                .IsRequired();

            confirmEmail.HasIndex(ce => ce.Address)
                .IsUnique();
        });

        builder.OwnsOne(user => user.DtBirth, dtbirth =>
        {
            dtbirth.Property(dtBirth => dtBirth.Date)
                .IsRequired();
        });
    }
}