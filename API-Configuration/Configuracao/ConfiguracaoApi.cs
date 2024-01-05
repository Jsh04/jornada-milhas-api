

using API_Domains.Indices;
using API_Domains.Interfaces;
using API_Domains.Repository;
using API_Domains.Services;
using API_Infraestrutura.Indices;
using Microsoft.Extensions.DependencyInjection;

namespace API_Configuration.Configuracao;

public static class ConfiguracaoApi
{
    public static void AddApiConfiguracao(this IServiceCollection services)
    {

        AddDependenciesInjectionsServices(services);
        AddDependenciesInjectionsExternal(services);
    }

    public static void AddDependenciesInjectionsServices(IServiceCollection services)
    {
        services.AddScoped<IDepoimentosService, DepoimentosService>();

        services.AddScoped<IRepository<DepoimentosIndex>, Repository<DepoimentosIndex>>(servicePrpvider => new Repository<DepoimentosIndex>("depoimentos"));

        services.AddScoped<IRepository<DestinosIndex>, Repository<DestinosIndex>>(serviceProvider => new Repository<DestinosIndex>("destinos"));

        services.AddScoped<IDestinosService, DestinosService>();
    }

    public static void AddDependenciesInjectionsExternal(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

}
