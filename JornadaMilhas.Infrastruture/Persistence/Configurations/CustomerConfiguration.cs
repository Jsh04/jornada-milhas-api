﻿using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Admins;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Depoiments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations
{
    public class CustomerConfiguration : UserConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Customer));

            builder.HasMany<Depoiment>()
                .WithOne(d => d.Customer)
                .HasForeignKey(d => d.CustomerId);

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Customer>(c => c.Id);
                
        }
    }
}
