using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restman.Application.Common.Models.AppConfig;
using Restman.Winform.Common.Sinks;
using Restman.Winform.Views;
using Serilog;

namespace Restman.Winform;

public static class DependencyInjection
{
    public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .Configure<HttpAppConfiguration>(configuration.GetSection("Http"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<HttpAppConfiguration>>().Value);

        return services;
    }

    public static IServiceCollection AddWinform(this IServiceCollection services, IConfiguration configuration)
    {
        var logForm = new LogForm();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Sink(new LogSink(logForm))
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
            loggingBuilder.AddSerilog());

        services.AddSingleton<MainForm>();
        services.AddSingleton(logForm);

        return services;
    }
}
