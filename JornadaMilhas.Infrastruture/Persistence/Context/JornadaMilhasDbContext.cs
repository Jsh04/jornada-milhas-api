using System.Reflection;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Context;

public class JornadaMilhasDbContext : DbContext
{
    public JornadaMilhasDbContext(DbContextOptions<JornadaMilhasDbContext> options) : base(options) { }

    public DbSet<Destiny> Destinos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Depoimento> Depoimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}