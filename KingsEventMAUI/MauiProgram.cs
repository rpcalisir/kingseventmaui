using KingsEventMAUI.Services;
using KingsEventMAUI.ViewModels;
using KingsEventMAUI.ViewModels.Dashboard;
using KingsEventMAUI.ViewModels.Startup;
using KingsEventMAUI.Views;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Startup;
using Microsoft.Extensions.Logging;

namespace KingsEventMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            //Views
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<DashboardPage>();

            //ViewModels
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<DashboardPageViewModel>();

            return builder.Build();
        }
    }
}