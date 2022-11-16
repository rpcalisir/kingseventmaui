using KingsEventMAUI.Models;
using KingsEventMAUI.ViewModels;
using KingsEventMAUI.Views;
using Microsoft.Extensions.Hosting;

namespace KingsEventMAUI
{
    public partial class App : Application
    {
        public static SignedInUserInfo SignedInUserInfo;
        public static string FreshFireBaseToken;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

    }
}