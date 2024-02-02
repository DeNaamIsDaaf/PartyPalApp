using Microsoft.Extensions.Logging;
using PartyPalApp.MVVM.Models;
using PartyPalApp.Repositories;
using CommunityToolkit.Maui;
using ZXing.Net.Maui.Controls;

namespace PartyPalApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseBarcodeReader();

            builder.Services.AddSingleton<BaseRepository<Event>>();
            builder.Services.AddSingleton<BaseRepository<Activity>>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
