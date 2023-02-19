using DataAccessHelper.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationHelpers.Middlewares;

namespace WebApplicationHelpers.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseCommonExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }

    public static void StartDbMigrators(this IApplicationBuilder app)
    {
        foreach (var dbMigrator in app.ApplicationServices.GetServices<IDbMigrator>())
            dbMigrator.Migrate();
    }
}