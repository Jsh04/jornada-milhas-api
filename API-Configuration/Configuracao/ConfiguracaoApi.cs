

using API_Domains.Indices;
using API_Domains.Interfaces;
using API_Domains.Interfaces.Depoimentos;
using API_Domains.Interfaces.Destinos;
using API_Domains.Interfaces.Usuarios;
using API_Domains.Repository;
using API_Domains.Services;
using API_Infraestrutura.Configuracao;
using API_Infraestrutura.Indices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        services.AddScoped<IDepoimentosRepository, DepoimentosRepository>();

        services.AddScoped<IDestinosRepository, DestinosRepository>();
        services.AddScoped<IDestinosService, DestinosService>();

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IUsuarioService, UsuarioService>();

        services.AddScoped<ITokenService, TokenService>();
    }

    public static void AddDependenciesInjectionsExternal(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddSingleton<FactoryElastic>();
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
