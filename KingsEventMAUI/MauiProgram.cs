using Firebase.Auth;
using KingsEventMAUI.Services;
using KingsEventMAUI.ViewModels;
using KingsEventMAUI.ViewModels.Dashboard;
using KingsEventMAUI.ViewModels.Operations;
using KingsEventMAUI.ViewModels.Startup;
using KingsEventMAUI.Views;
using KingsEventMAUI.Views.Dashboard;
using KingsEventMAUI.Views.Operations;
using KingsEventMAUI.Views.Startup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

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

            var executingAssembly = Assembly.GetExecutingAssembly();

            using var stream = executingAssembly.GetManifestResourceStream("KingsEventMAUI.appsettings.json");

            var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

            builder.Configuration.AddConfiguration(config);


#if DEBUG
            builder.Logging.AddDebug();
#endif
            //Views
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<SignInPage>();
            builder.Services.AddSingleton<SignUpPage>();
            builder.Services.AddSingleton<DashboardPage>();
            builder.Services.AddSingleton<EventFlyersPage>();
            builder.Services.AddSingleton<PhoneSignInPage>();

            //ViewModels
            builder.Services.AddSingleton<LoadingPageViewModel>();
            builder.Services.AddSingleton<SignInPageViewModel>();
            builder.Services.AddSingleton<SignUpPageViewModel>();
            builder.Services.AddSingleton<DashboardPageViewModel>();
            builder.Services.AddSingleton<EventFlyersPageViewModel>();
            builder.Services.AddSingleton<PhoneSignInPageViewModel>();

            //Services
            builder.Services.AddSingleton<EventFlyerService>();

            string apiKey = config.GetSection("FIREBASE_API_KEY").Value;

            //Firebase
            builder.Services.AddSingleton(new FirebaseAuthProvider(new FirebaseConfig(apiKey)));



            return builder.Build();
        }
    }
}