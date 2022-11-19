using KingsEventMAUI.ViewModels;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Startup;

namespace KingsEventMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = new AppShellViewModel();

            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(PhoneSignInPage), typeof(PhoneSignInPage));
        }
    }
}