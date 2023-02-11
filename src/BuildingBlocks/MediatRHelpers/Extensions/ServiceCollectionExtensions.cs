using MediatR;
using MediatRHelpers.CommonBehaviours;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRHelpers.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUnhandledExceptionBehaviour(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        return services;
    }

    public static IServiceCollection AddValidationBehaviour(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}
