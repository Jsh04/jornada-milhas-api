using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhasTest.IntegrationsTest.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JornadaMilhasTest.IntegrationsTest.WebApplicationFactory;

public class WebApplicationFactoryJornada<T> : WebApplicationFactory<T> where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            RemoveDbContextProduction(services);
            AddDbContextTest(services);
        });

        base.ConfigureWebHost(builder);
    }

    private void RemoveDbContextProduction(IServiceCollection services)
    {
        var dbContextDescriptor = services.SingleOrDefault(
            d => d.ServiceType ==
                 typeof(DbContextOptions<JornadaMilhasDbContext>));

        services.Remove(dbContextDescriptor);
    }

    private void AddDbContextTest(IServiceCollection services)
    {
        services.AddDbContext<JornadaMilhasDbContext>(opts => { opts.UseSqlServer(TestHelper.ConnectionString); });
    }
}