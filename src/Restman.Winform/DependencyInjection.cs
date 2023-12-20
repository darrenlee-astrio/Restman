using Microsoft.Extensions.DependencyInjection;
using Restman.Winform.Logging.Sinks;
using Serilog;

namespace Restman.Winform;

public static class DependencyInjection
{
    public static IServiceCollection AddWinform(this IServiceCollection services)
    {
        var logForm = new LogForm();
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
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
