using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace University.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegistrarApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
