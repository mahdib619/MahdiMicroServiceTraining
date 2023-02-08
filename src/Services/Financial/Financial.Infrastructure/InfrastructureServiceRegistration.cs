using Financial.Application.Contracts.Persistence;
using Financial.Infrastructure.Persistence;
using Financial.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection RegistrarInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinancialDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("FinancialDb")));

        services.AddScoped<ICourseFeesRepository, CourseFeesRepository>();
        services.AddScoped<IDebtsRepository, DebtsRepository>();
        services.AddScoped<IMajorFeesRepository, MajorFeesRepository>();
        services.AddScoped<IPaymentsRepository, PaymentsRepository>();

        return services;
    }
}
