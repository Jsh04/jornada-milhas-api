using System.Reflection;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Common.Persistence.Queue;
using JornadaMilhas.Core.Entities.Admins;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.ValueObjects.Locales;
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
    public virtual DbSet<Depoiment> Depoimentos { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<OutboxMessage> OutboxMessage { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public DbSet<Company> Company { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
    }
}