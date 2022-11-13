using KingsEventMAUI.Services;
using KingsEventMAUI.ViewModels;
using KingsEventMAUI.Views;
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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<EventFlyerPage>();
            builder.Services.AddSingleton<EventFlyerService>();

            return builder.Build();
        }
    }
}