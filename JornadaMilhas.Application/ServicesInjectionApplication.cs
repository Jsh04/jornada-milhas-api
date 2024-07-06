using FluentValidation.AspNetCore;
using FluentValidation;
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.Services;
using JornadaMilhas.Application.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Interfaces.Services;

namespace JornadaMilhas.Application
{
    public static class ServicesInjectionApplication
    {
        public static IServiceCollection GetServicesInjectiosOfApplication(this IServiceCollection services)
        {
            return services.AddDependencyInjectionOfApplication()
                .AddServicesOfMediat()
                .AddServicesFluentValidation();
        }

        public static IServiceCollection AddDependencyInjectionOfApplication(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

        public static IServiceCollection AddServicesOfMediat(this IServiceCollection services)
        {
            services.AddMediatR(opts => opts.RegisterServicesFromAssembly(typeof(RegisterDestinyCommand).Assembly));

            return services;
        }

        public static IServiceCollection AddServicesFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(RegisterDestinyValidator), ServiceLifetime.Transient);

            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
