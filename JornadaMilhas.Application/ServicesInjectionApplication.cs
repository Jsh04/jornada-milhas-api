using FluentValidation;
using FluentValidation.AspNetCore;
using JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;
using JornadaMilhas.Application.EventHandlers;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Services;
using JornadaMilhas.Core.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JornadaMilhas.Application;

public static class ServicesInjectionApplication
{
    public static IServiceCollection GetServicesInjectiosOfApplication(this IServiceCollection services)
    {
        return services.AddDependencyInjectionOfApplication()
            .AddServicesOfMediat()
            .AddHandlersNotification()
            .AddServicesFluentValidation();
    }

    public static IServiceCollection AddDependencyInjectionOfApplication(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDestinyService, DestinyService>();

        services.AddSingleton<IUploadService, UploadS3Service>();

        return services;
    }

    public static IServiceCollection AddServicesOfMediat(this IServiceCollection services)
    {
        services.AddMediatR(opts => opts.RegisterServicesFromAssembly(typeof(RegisterDestinyCommand).Assembly));

        return services;
    }

    private static IServiceCollection AddHandlersNotification(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler<EmailCreateUserEvent>, SendEmailEventHandler>();
        return services;
    }

    public static IServiceCollection AddServicesFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(RegisterDestinyValidator), ServiceLifetime.Transient);

        services.AddFluentValidationAutoValidation();

        return services;
    }
}