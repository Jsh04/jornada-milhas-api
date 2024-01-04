

using API_Domains.Interfaces;
using API_Domains.Repository;
using API_Domains.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API_Configuration.Configuracao;

public static class ConfiguracaoApi
{
    public static void AddApiConfiguracao(this IServiceCollection services)
    {

        services.AddScoped<IDepoimentosService, DepoimentosService>();
        services.AddScoped<IDepoimentosRepository, DepoimentoRepository>();
        services.AddScoped<IChatGPTService, ChatGPTService>();
        services.AddScoped<IDestinosRepository, DestinosRepository>();
        services.AddScoped<IDestinosService, DestinosService>();


    }

}
