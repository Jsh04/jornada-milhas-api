using System.Reflection;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Entities.Users.UserAdmin;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Context;

public class JornadaMilhasDbContext : DbContext
{

    public DbSet<Destiny> Destinos { get; set; }
    public DbSet<UserLimited> UsersLimited { get; set; }
    public DbSet<UserAdmin> UsersAdmin { get; set; }
    public DbSet<Depoimento> Depoimentos { get; set; }

    public JornadaMilhasDbContext(DbContextOptions<JornadaMilhasDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}