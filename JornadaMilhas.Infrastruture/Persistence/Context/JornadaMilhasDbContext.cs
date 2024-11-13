using System.Reflection;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Common.Persistence.Queue;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Entities.Users.UserAdmin;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Context;

public class JornadaMilhasDbContext : DbContext
{

    public virtual DbSet<Destiny> Destinos { get; set; }
    public virtual DbSet<UserLimited> UsersLimited { get; set; }
    
    public virtual DbSet<UserAdmin> UsersAdmin { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Depoiment> Depoimentos { get; set; }

    public virtual DbSet<Company> Companies { get; set; }
    
    public virtual DbSet<OutboxMessage> OutboxMessage { get; set; }

    public DbSet<Company> Company { get; set; }

    public JornadaMilhasDbContext() : base()
    {
        
    }

    public JornadaMilhasDbContext(DbContextOptions<JornadaMilhasDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
    }
}