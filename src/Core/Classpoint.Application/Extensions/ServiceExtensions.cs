using ClassPoint.Application.Behaviors;
using ClassPoint.Domain.Extensions;
using ClassPoint.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClassPoint.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services
        .AddServicesForInterface(typeof(ITransientService), ServiceLifetime.Transient)
        .AddServicesForInterface(typeof(IScopedService), ServiceLifetime.Scoped);
        return services;
    }
}