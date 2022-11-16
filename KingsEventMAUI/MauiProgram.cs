using KingsEventMAUI.Services;
using KingsEventMAUI.ViewModels;
using KingsEventMAUI.ViewModels.Dashboard;
using KingsEventMAUI.ViewModels.Operations;
using KingsEventMAUI.ViewModels.Startup;
using KingsEventMAUI.Views;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Operations;
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
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<SignInPage>();
            builder.Services.AddSingleton<SignUpPage>();
            builder.Services.AddSingleton<DashboardPage>();
            builder.Services.AddSingleton<EventFlyersPage>();

            //ViewModels
            builder.Services.AddSingleton<LoadingPageViewModel>();
            builder.Services.AddSingleton<SignInPageViewModel>();
            builder.Services.AddSingleton<SignUpPageViewModel>();
            builder.Services.AddSingleton<DashboardPageViewModel>();
            builder.Services.AddSingleton<EventFlyersPageViewModel>();

            //Services
            builder.Services.AddSingleton<EventFlyerService>();

            return builder.Build();
        }
    }
}