using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Application.Contracts.Persistence;
using University.Infrasturcture.Persistence;
using University.Infrasturcture.Repositories;

namespace University.Infrasturcture;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection RegistrarInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UniDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("UniDb")));

        services.AddScoped<ICoursesRepository, CoursesRepository>();
        services.AddScoped<ITermsRepository, TermsRepository>();
        services.AddScoped<IStudentsRepository, StudentsRepository>();

        return services;
    }
}
