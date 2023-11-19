using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using VirusStatistics.WPF.ViewModels;
using VirusStatistics.WPF.Views;

namespace VirusStatistics.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = CreateHostBuilder(new string[] { }).Build();
        }
        private IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args);
            host.ConfigureServices((context, services) =>
            {
                // Конфигурация сервисов, добавляемых в DI
                services.AddViews();
            });
            return host;
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindowV>();
            window.DataContext = _host.Services.GetRequiredService<MainWindowVM>();
            window.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }

}
