

using JornadaMilhas.Core.Interfaces;
using JornadaMilhas.Core.Interfaces.Depoimentos;
using JornadaMilhas.Infrastruture;
using JornadaMilhas.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API_Domains.Repository;
using JornadaMilhas.Application.Messagings.Senders;
using JornadaMilhas.Core.Interfaces.Destinos;
using JornadaMilhas.Core.Interfaces.Usuarios;

namespace JornadaMilhas.API;

public static class ConfigurationApi
{
    public static void AddApiConfiguracao(this IServiceCollection services)
    {

        AddDependenciesInjectionsServices(services);
        AddDependenciesInjectionsExternal(services);
    }

    public static void AddDependenciesInjectionsServices(IServiceCollection services)
    {
        services.AddScoped<IDepoimentosService, DepoimentosService>();

        services.AddScoped<IDestinosService, DestinosService>();

        services.AddScoped<IUsuarioService, UsuarioService>();

        services.AddScoped<ITokenService, TokenService>();

        services.AddSingleton<IUnitOfWork, UnitOfWork>();


    }

    public static void AddDependenciesInjectionsExternal(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddSingleton<FactoryElastic>();

        services.AddSingleton<SendEmailMessage>();
    }

    public static void AddAuthenticationWithJWT(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var secretKey = builder.Configuration["SymmetricSecurityKey"]; 
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }

}
