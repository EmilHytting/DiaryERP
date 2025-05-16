using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Threading.Tasks;
using DiaryERP.Utils;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Diagnostics;

namespace DiaryERP.Desktop
{
    internal sealed class Program
    {
        [STAThread]
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            bool canConnect = await ConnectionTester.TestConnectionAsync(connectionString);

            Debug.Print(canConnect ? "Databaseforbindelse OK!" : "Databaseforbindelse FEJLEDE!");

            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .UseReactiveUI()
                .LogToTrace();
    }
}
