using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quadro_de_pendencias.Data;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Services;
using Quadro_de_pendencias.ViewModels;
using Quadro_de_pendencias.Views.Popups;
using IPopupHelperService = Quadro_de_pendencias.Interfaces.IPopupHelperService;

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

            //SQLite
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "pendencias.db3");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));
            builder.Services.AddScoped<DatabaseService>();

            // Services
            builder.Services.AddSingleton<IBoardService, BoardStorageService>();
            builder.Services.AddSingleton<IPopupHelperService, PopupService>();

            //Popups
            builder.Services.AddTransient<NewBoardPopup>();
            builder.Services.AddTransient<NewGroupPopup>();
            builder.Services.AddTransient<NewCardPopup>();

            // ViewModels
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<BoardViewModel>();
            builder.Services.AddTransient<GroupViewModel>();
            builder.Services.AddTransient<CardViewModel>();
            builder.Services.AddTransient<NewBoardPopupViewModel>();
            builder.Services.AddTransient<NewGroupPopupViewModel>();
            builder.Services.AddTransient<NewCardPopupViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
