using System.Reflection;
using JornadaMilhas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Context;

public class JornadaMilhasDbContext : DbContext
{
    public JornadaMilhasDbContext(DbContextOptions<JornadaMilhasDbContext> options) : base(options) { }

    public DbSet<Destino> Destinos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Depoimento> Depoimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}