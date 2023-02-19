using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataAccessHelper.EntityFramework;

public class DbContextMigrator<T> : IDbMigrator where T : DbContext
{
    private const int MAX_TRY_COUNT = 30;
    private readonly IServiceProvider _serviceProvider;
    private readonly CancellationToken _cancellationToken;
    private readonly Func<T, Task> _postMigrateAction;

    public DbContextMigrator(IServiceProvider serviceProvider, Func<T, Task> postMigrateAction = null, CancellationToken cancellationToken = default)
    {
        _serviceProvider = serviceProvider;
        _cancellationToken = cancellationToken;
        _postMigrateAction = postMigrateAction;
    }

    /// <summary>
    /// Starts trying to migrate database in background.
    /// </summary>
    public void Migrate()
    {
        Task.Run(DoMigrate, _cancellationToken);
    }

    private async Task DoMigrate()
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<T>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<DbContextMigrator<T>>>();

        var timer = new PeriodicTimer(TimeSpan.FromSeconds(15));
        var tryCount = 0;
        while (await timer.WaitForNextTickAsync(_cancellationToken))
        {
            try
            {
                tryCount++;

                await context.Database.MigrateAsync(_cancellationToken);
                logger.LogInformation("{DbContextName} migrated sucessfully after {TryCount} tries.", typeof(T).Name, tryCount);

                await InvokePostAction(context, logger);

                timer.Dispose();
            }
            catch (Exception e) when (tryCount >= MAX_TRY_COUNT)
            {
                timer.Dispose();
                logger.LogError(e, "Migrating {DbContextName} failed after {TryCount} tries!", typeof(T).Name, tryCount);
            }
            catch (Exception e)
            {
                logger.LogWarning(e, "Retrying to migrate {DbContextName} {TryCount}/{MaxTryCount}.", typeof(T).Name, tryCount, MAX_TRY_COUNT);
            }
        }
    }

    private async Task InvokePostAction(T context, ILogger logger)
    {
        if (_postMigrateAction is not null)
        {
            try
            {
                await _postMigrateAction(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Invoking post migrate action failed for {DbContextName}!", typeof(T).Name);
            }
        }
    }
}