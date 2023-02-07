using System.Reflection;
using Financial.Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegistrarApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        return services;
    }
}
