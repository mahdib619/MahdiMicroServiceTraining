using FluentValidation;
using MassTransit;
using MediatR;
using MediatRHelpers.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace University.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegistrarApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Scoped, null, true);

        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((_, cfg) => cfg.Host(configuration["EventBusSettings:HostAddress"]));
        });

        services.AddUnhandledExceptionBehaviour();
        services.AddValidationBehaviour();

        return services;
    }
}
