using FluentValidation;
using MediatR;
using MediatRHelpers.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace University.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegistrarApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Scoped, null, true);

        services.AddUnhandledExceptionBehaviour();
        services.AddValidationBehaviour();

        return services;
    }
}
