using System.Reflection;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Core.Entities.Admins;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.ValueObjects.Locales;
using JornadaMilhas.Infrastruture.Message.Outbox;
using JornadaMilhas.Infrastruture.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Context;

public class JornadaMilhasDbContext : DbContext
{
    public JornadaMilhasDbContext()
    {
    }

    public JornadaMilhasDbContext(DbContextOptions<JornadaMilhasDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Destination> Destinations { get; set; }
    public virtual DbSet<Depoiment> Testimonials { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<OutboxMessage> OutboxMessage { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Owned<Address>();
        modelBuilder.Owned<Cpf>();
        modelBuilder.Owned<DateOfBirth>();
        modelBuilder.Owned<Email>();
        modelBuilder.Owned<Phone>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
    }
}