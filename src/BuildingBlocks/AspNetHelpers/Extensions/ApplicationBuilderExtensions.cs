using DataAccessHelper.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
        var baseContextType = typeof(DbContext);
        var migratorType = typeof(DbContextMigrator<>);

        var contextTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.DefinedTypes).Where(e => e.IsAssignableTo(baseContextType));
        var genericMigratorTypes = contextTypes.Select(e => migratorType.MakeGenericType(e));

        foreach (var mType in genericMigratorTypes)
        {
            var migrator = app.ApplicationServices.GetService(mType);
            if (migrator is null)
                continue;

            var migrateMethod = migrator.GetType().GetMethod("Migrate")!;
            migrateMethod.Invoke(migrator, null);
        }
    }
}