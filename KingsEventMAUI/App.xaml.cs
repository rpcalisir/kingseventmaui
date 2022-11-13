using KingsEventMAUI.ViewModels;
using Microsoft.Extensions.Hosting;

namespace KingsEventMAUI
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            //MainPage = new AppShell()
            //{
            //    BindingContext = new MainViewModel()
            //};

            //_host = Host.CreateDefaultBuilder()
            //    .ConfigureServices((context, service) =>
            //    {
            //        service.AddSingleton(() => new MainPage());
            //    })
            //    .Build();
        }

    }
}