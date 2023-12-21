using Microsoft.Extensions.DependencyInjection;
using Restman.Winform.Common.Sinks;
using Serilog;
using Serilog.Events;

namespace Restman.Winform;

public static class DependencyInjection
{
    public static IServiceCollection AddWinform(this IServiceCollection services)
    {
        var logForm = new LogForm();
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Sink(new LogSink(logForm))
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
            loggingBuilder.AddSerilog());

        services.AddSingleton<MainForm>();
        services.AddSingleton(logForm);

        return services;
    }
}
