using Game.ViewModels;
using Game.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Game
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainView>();
            services.AddSingleton<MainContentView>();
            services.AddSingleton<ChangeUserView>();
            services.AddSingleton<ChangeUserViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainView = serviceProvider.GetService<MainView>();
            mainView.Show();
        }
    }

}
