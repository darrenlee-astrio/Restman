using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restman.Application;
using Restman.Winform.Views;
using Serilog;
using WinformsApp = System.Windows.Forms.Application;

namespace Restman.Winform;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        WinformsApp.SetHighDpiMode(HighDpiMode.SystemAware);
        WinformsApp.EnableVisualStyles();
        WinformsApp.SetCompatibleTextRenderingDefault(false);

        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        WinformsApp.ThreadException += Application_ThreadException;
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)
            .AddConfiguration(configuration)
            .AddWinform(configuration)
            .AddApplication(configuration)
            .BuildServiceProvider();

        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        WinformsApp.Run(mainForm);
        AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
    }

    private static void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        HandleException(e.Exception);
    }
    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        HandleException(e.Exception);
    }
    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Exception? exception = e.ExceptionObject as Exception;

        if (exception is null)
        {
            return;
        }

        HandleException(exception);
    }
    private static void HandleException(Exception exception)
    {
        var errorMessage = $"An unexpected error occurred: {exception}";
        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        try
        {
            File.WriteAllText(@$"Logs\Unhandled\{DateTime.Now.ToString("yyyyMMdd_hhmmss_tt")}.txt", errorMessage);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unable to create log file for unhandled exception: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Environment.Exit(1);
        }
    }
}