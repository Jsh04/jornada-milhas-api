using System.Text.Json.Serialization;
using JornadaMilhas.API.Middleware;
using JornadaMilhas.Application;
using JornadaMilhas.Infrastruture;

namespace JornadaMilhas.API.Extensions;

public static class ConfigurationApi
{
    public static void AddApiConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
        builder.Services.GetServicesInjectionsOfInfrastructure(builder.Configuration, builder.Environment);
        builder.Services.GetServicesInjectiosOfApplication();
        builder.Services.AddTransient<GlobalExceptionHandler>();

        builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    }
}