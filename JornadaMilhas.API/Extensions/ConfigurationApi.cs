

using System.Text.Json.Serialization;
using JornadaMilhas.API.Middleware;
using JornadaMilhas.Application;
using JornadaMilhas.Infrastruture;

namespace JornadaMilhas.API;

public static class ConfigurationApi
{
    public static void AddApiConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.GetServicesInjectiosOfInfraestruture(builder.Configuration);
        builder.Services.GetServicesInjectiosOfApplication();

        builder.Services.AddTransient<GlobalExceptionHandler>();

        builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    }

}
