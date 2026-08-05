using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Services;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias
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
                });


            // Services
            builder.Services.AddSingleton<IBoardService, BoardStorageService>();

            // ViewModels
            builder.Services.AddTransient<BoardViewModel>();
            builder.Services.AddTransient<CardGroupViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
