using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JornadaMilhas.Application.Interfaces.Gateways;
using JornadaMilhas.Application.Interfaces.MessageBus;
using JornadaMilhas.Application.Interfaces.Security;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Common.Options;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.BackgroundJobs;
using JornadaMilhas.Infrastruture.Gateway;
using JornadaMilhas.Infrastruture.Interceptors;
using JornadaMilhas.Infrastruture.MessageBus;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhas.Infrastruture.Persistence.Repository;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using JornadaMilhas.Infrastruture.Security;
using JornadaMilhas.Infrastruture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace JornadaMilhas.Infrastruture;

public static class ServicesInjectionsInfraestruture
{
    public static IServiceCollection GetServicesInjectionsOfInfrastructure(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        return services.AddServiceDbContext(configuration)
            .AddInjectionRepositories()
            .AddOptionsConfigure(configuration)
            .AddInjectionBackgroundJobs()
            .AddInjectionServices()
            .AddInjectionGateways()
            .AddServicesTokenReader(configuration, environment);
    }

    private static IServiceCollection AddOptionsConfigure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .Configure<TokenOptions>(configuration.GetSection("Token"))
            .AddOptions<TokenOptions>()
            .ValidateDataAnnotations();

        services.Configure<RabbitMqOptions>(configuration.GetSection("RabbitMq"))
            .AddOptions<RabbitMqOptions>()
            .ValidateDataAnnotations();

        return services;
    }

    private static IServiceCollection AddInjectionGateways(this IServiceCollection services)
    {
        services.AddTransient<IUploadService, UploadS3Service>();
        
        return services;
    }
    
    private static IServiceCollection AddInjectionServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }

    private static IServiceCollection AddServiceDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<JornadaMilhasDbContext>((serviceProvider, opts) =>
            opts.UseSqlServer(configuration["ConnectionStringSqlServer"])
                .AddInterceptors(serviceProvider.GetRequiredService<CustomerAddedInterceptor>()));

        return services;
    }

    private static IServiceCollection AddServicesTokenReader(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        var secretKey = configuration["SymmetricSecurityKey"];
        var key = Encoding.ASCII.GetBytes(secretKey);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = !environment.IsDevelopment();
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    RequireExpirationTime = true,
                    ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256Signature }
                };
            });
        return services;
    }

    private static IServiceCollection AddInjectionBackgroundJobs(this IServiceCollection services)
    {
        services.AddHostedService<SendEmailToRabbitJob>();
        return services;
    }

    private static IServiceCollection AddInjectionRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IDepoimentRepository, DepoimentRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IPlaneRepository, PlaneRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<ITokenGenerator, TokenGenerator>();

        services.AddSingleton<JwtSecurityTokenHandler>();
        services.AddSingleton<CustomerAddedInterceptor>();
        services.AddSingleton<IMessageBusProducerService, MessageBusProducerService>();

        return services;
    }
}