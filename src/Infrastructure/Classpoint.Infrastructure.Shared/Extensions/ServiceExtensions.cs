using ClassPoint.Domain.Extensions;
using ClassPoint.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassPoint.Infrastructure.Shared.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureSharedLayer(this IServiceCollection services)
    {
        services
        .AddServicesForInterface(typeof(ITransientService), ServiceLifetime.Transient)
        .AddServicesForInterface(typeof(IScopedService), ServiceLifetime.Scoped)
        .AddServicesForInterface(typeof(ISingletonService), ServiceLifetime.Singleton);

        return services;
    }
}