using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        var logForm = new LogForm();

        using var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddWinform();
                services.AddApplication();
            })
            .Build();

        var mainForm = host.Services.GetRequiredService<MainForm>();
        WinformsApp.Run(mainForm);

        Log.CloseAndFlush();
    }
}