using ClassPoint.Application.Interfaces;
using ClassPoint.Domain.Extensions;
using ClassPoint.Domain.Interfaces;
using ClassPoint.Infrastructure.Persistance.Context;
using ClassPoint.Infrastructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassPoint.Infrastructure.Persistance.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<IDapperRepository>(q => new DapperRepository(configuration.GetConnectionString("DefaultConnection")));

        services
        .AddServicesForInterface(typeof(ITransientService), ServiceLifetime.Transient)
        .AddServicesForInterface(typeof(IScopedService), ServiceLifetime.Scoped);
        return services;
    }
}