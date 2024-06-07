using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JornadaMilhas.Application.Messagings.Senders;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhas.Infrastruture.Persistence.Repository;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using JornadaMilhas.Application.Validations;
using FluentValidation;
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Infrastruture.Persistence.Repository.UserRepository;

namespace JornadaMilhas.API;

public static class ConfigurationApi
{
    public static void AddApiConfiguracao(this WebApplicationBuilder builder)
    {
        AddDependenciesInjectionsServices(builder);
        AddDependenciesInjectionsExternal(builder);
        
   
        AddAuthenticationWithJWT(builder);
        
        builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        
    }

    public static void AddDependenciesInjectionsServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        
        services.AddScoped<IRepositoryDestino, RepositoryDestino>();
        services.AddScoped<IUserLimitedRepository, UserLimitedRepository>();
        services.AddScoped<IDepoimentRepository, DepoimentRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddDependenciesInjectionsExternal(WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<JornadaMilhasDbContext>(opts => opts.UseSqlServer(builder
            .Configuration["ConnectionStringSqlServer"]));

        builder.Services.AddSingleton<SendEmailMessage>();

        builder.Services.AddMediatR(opts =>
        {
            opts.RegisterServicesFromAssembly(typeof(RegisterDestinyCommand).Assembly);
        });

        builder.Services.AddValidatorsFromAssemblyContaining(typeof(RegisterDestinyValidator), ServiceLifetime.Transient);

        builder.Services.AddFluentValidationAutoValidation();
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
