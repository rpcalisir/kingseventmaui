using KingsEventMAUI.ViewModels;
using KingsEventMAUI.Views;
using Microsoft.Extensions.Hosting;

namespace KingsEventMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

    }
}