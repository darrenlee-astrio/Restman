using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restman.Application.Common.Behaviors;
using Restman.Application.Common.Constants;
using Restman.Application.Common.Models.AppConfig;
using Restman.Application.Common.Pipelines;
using Restman.Application.Http;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Restman.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(CancellationPipelineBehavior<,>))
            .AddValidatorsFromAssembly(typeof(IApplicationMarker).Assembly)
            .AddHttp(configuration);

        return services;
    }

    private static IServiceCollection AddHttp(this IServiceCollection services, IConfiguration configuration)
    {
        var logger = services.BuildServiceProvider().GetRequiredService<ILogger<CommonHttpCommandHandler>>();

        var httpAppConfiguration = services.BuildServiceProvider()
            .GetRequiredService<IOptions<HttpAppConfiguration>>().Value;

        services.AddTransient<HttpLoggingHandler>();

        services
            .AddHttpClient(DataHolder.DefaultHttpClient, client =>
            {
                client.Timeout = TimeSpan.FromSeconds(httpAppConfiguration.RequestTimeOut);
            })
            .AddHttpMessageHandler<HttpLoggingHandler>();

        foreach (var name in CollectionId.All)
        {
            services
                .AddHttpClient(name, client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(httpAppConfiguration.RequestTimeOut);
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    var handler = new HttpClientHandler();
                    string? clientCertificatePath = configuration[$"{name}:SSL:ClientCertificateFilePath"];
                    string? clientCertificatePassword = configuration[$"{name}:SSL:ClientCertificatePassword"];
                    string? serverCertificateHashString = configuration[$"{name}:SSL:ServerCertificateHashString"];

                    if (clientCertificatePath != null && File.Exists(clientCertificatePath))
                    {
                        logger.LogInformation("Client SSL Certificate: {path}", clientCertificatePath);
                        handler.ClientCertificates.Add(new X509Certificate2(clientCertificatePath, clientCertificatePassword));
                    }
                    handler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
                        ServerCertificateValidationCallback(sender, certificate, chain, sslPolicyErrors, logger, serverCertificateHashString);
                    return handler;
                })
                .AddHttpMessageHandler<HttpLoggingHandler>();
        }
        return services;
    }

    private static bool ServerCertificateValidationCallback(HttpRequestMessage sender,
                    X509Certificate2? certificate,
                    X509Chain? chain,
                    SslPolicyErrors sslPolicyErrors,
                    ILogger<CommonHttpCommandHandler> logger,
                    string? expectedCertHash = null)
    {
        logger.LogInformation("Server SSL Certificate Hash String: {cert}", certificate?.GetCertHashString());

        return (!string.IsNullOrEmpty(expectedCertHash)) ?
            (certificate != null && certificate.GetCertHashString() == expectedCertHash) : true;
    }
}
