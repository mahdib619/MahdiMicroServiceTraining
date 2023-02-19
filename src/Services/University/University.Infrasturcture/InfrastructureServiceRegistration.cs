using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DataAccessHelper.EntityFramework;
using Microsoft.Extensions.DependencyInjection.Extensions;
using University.Application.Contracts.Persistence;
using University.Application.Contracts.SyncDataServices;
using University.Infrasturcture.Persistence;
using University.Infrasturcture.Repositories;
using University.Infrasturcture.SyncDataServices.Grpc;

namespace University.Infrasturcture;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection RegistrarInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddDbContext<UniDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("UniDb")));

        services.AddScoped<ICoursesRepository, CoursesRepository>();
        services.AddScoped<ITermsRepository, TermsRepository>();
        services.AddScoped<IStudentsRepository, StudentsRepository>();
        services.AddScoped<IStudentCoursesRepository, StudentCoursesRepository>();
        services.AddScoped<IMajorsRepository, MajorsRepository>();

        services.AddScoped<IStudentBalanceDataClient, GrpcStudentBalanceDataClient>();

        var dbMigrator = new DbContextMigrator<UniDbContext>(services.BuildServiceProvider(), UniDbSeeder.SeedAsync);
        services.TryAddEnumerable(new ServiceDescriptor(typeof(IDbMigrator), dbMigrator));

        return services;
    }
}
