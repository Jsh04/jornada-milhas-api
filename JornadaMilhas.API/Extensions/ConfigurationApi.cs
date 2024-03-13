using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JornadaMilhas.Application.Messagings.Senders;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhas.Infrastruture.Persistence.Repository;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.API;

public static class ConfigurationApi
{
    public static void AddApiConfiguracao(this WebApplicationBuilder builder)
    {

        AddDependenciesInjectionsServices(builder);
        AddDependenciesInjectionsExternal(builder);
        AddAuthenticationWithJWT(builder);
    }

    public static void AddDependenciesInjectionsServices(WebApplicationBuilder builder)
    {

        var services = builder.Services;

        services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
        services.AddScoped<IRepositoryDestino, RepositoryDestino>();
        services.AddScoped<IRepositoryDepoimento, RepositoryDepoimento>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

    public static void AddDependenciesInjectionsExternal(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddDbContext<JornadaMilhasDbContext>(opts => opts.UseSqlServer(builder
            .Configuration["ConnectionStringSqlServer"]));
        builder.Services.AddSingleton<SendEmailMessage>();
    }

    public static void AddAuthenticationWithJWT(WebApplicationBuilder builder)
    {
        var secretKey = builder.Configuration["SymmetricSecurityKey"];
        builder.Services.AddAuthentication(x =>
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
