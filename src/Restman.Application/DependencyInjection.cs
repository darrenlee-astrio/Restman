using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Restman.Application.Common.Behaviors;
using System.Reflection;

namespace Restman.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CancellationPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(IApplicationMarker).Assembly);
        services.AddHttpClient();
        return services;
    }
}
