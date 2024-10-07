

using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhas.Infrastruture.Persistence.Repository.UserRepository;
using JornadaMilhas.Infrastruture.Persistence.Repository;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JornadaMilhas.Common.Options;
using JornadaMilhas.Infrastruture.Security;
using System.IdentityModel.Tokens.Jwt;
using JornadaMilhas.Infrastruture.Interceptors;
using JornadaMilhas.Infrastruture.BackgroundJobs;
using JornadaMilhas.Infrastruture.MessageBus;

namespace JornadaMilhas.Infrastruture
{
    public static class ServicesInjectionsInfraestruture
    {
        public static IServiceCollection GetServicesInjectiosOfInfraestruture(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddServiceDbContext(configuration)
                .AddInjectionRepositorys()
                .AddOptionsConfigure(configuration)
                .AddInjectionBackgroundJobs()
                .AddServicesTokenReader(configuration);
        }

        private static IServiceCollection AddOptionsConfigure(this IServiceCollection services, IConfiguration configuration)
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

        private static IServiceCollection AddServiceDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JornadaMilhasDbContext>((serviceProvider, opts) => 
                opts.UseSqlServer(configuration["ConnectionStringSqlServer"])
                    .AddInterceptors(serviceProvider.GetRequiredService<PublishEventSendEmailToQueueObj>()));

            return services;
        }

        private static IServiceCollection AddServicesTokenReader(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["SymmetricSecurityKey"];
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

            return services;
        }

        private static IServiceCollection AddInjectionBackgroundJobs(this IServiceCollection services)
        {
            services.AddHostedService<SendEmailToRabbitJob>();
            return services;
        }

        private static IServiceCollection AddInjectionRepositorys(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryDestino, DestinyRepository>();
            services.AddScoped<IUserLimitedRepository, UserLimitedRepository>();
            services.AddScoped<IDepoimentRepository, DepoimentRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddSingleton<JwtSecurityTokenHandler>();
            services.AddSingleton<PublishEventSendEmailToQueueObj>();
            services.AddSingleton<IMessageBusProducerService, MessageBusProducerService>();

            return services;

        }


    }
}
