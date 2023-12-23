using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Restman.Application.Common.Behaviors;
using Restman.Application.Common.Constants;
using Restman.Application.Common.Pipelines;
using Restman.Application.Http;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Restman.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddTransient<HttpLoggingHandler>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CancellationPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(IApplicationMarker).Assembly);
        services.AddHttpClient(nameof(Application))
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (
                    HttpRequestMessage sender,
                    X509Certificate2? certificate,
                    X509Chain? chain,
                    SslPolicyErrors sslPolicyErrors) =>
                {
                    var logger = services.BuildServiceProvider()
                        .GetRequiredService<ILogger<CommonHttpCommandHandler>>();

                    logger.LogInformation("Server ssl cert hash: {cert}", certificate?.GetCertHashString());

                    if (sender.Headers.TryGetValues(DataHolder.ExpectedServerCertHashHeaderName, out var expectedHashValues)
                            && expectedHashValues is not null)
                    {
                        // We want to make sure that the server is recognised before we talk to them
                        return certificate != null && certificate.GetCertHashString() == expectedHashValues.First();
                    }
                    
                    // If we did not provide the expected cert, we treat it as we do not want to validate server ssl
                    // Hence, no expected cert => we do not challenge who the server is
                    return true;
                };
                return handler;
            })
            .AddHttpMessageHandler<HttpLoggingHandler>();
        return services;
    }
}
