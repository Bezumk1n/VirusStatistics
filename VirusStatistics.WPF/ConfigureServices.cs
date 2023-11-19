using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using VirusStatistics.WPF.Common;
using VirusStatistics.WPF.ViewModels;
using VirusStatistics.WPF.Views;

namespace VirusStatistics.WPF
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            // Фабрика ViewModel
            services.AddSingleton<Func<Type, BaseVM>>(serviceProvider => viewModelType => (BaseVM)serviceProvider.GetRequiredService(viewModelType));

            services.AddSingleton<LoginV>();
            services.AddSingleton<LoginVM>();
            services.AddSingleton<MainWindowV>();
            services.AddSingleton<MainWindowVM>();
            return services;
        }
    }
}
