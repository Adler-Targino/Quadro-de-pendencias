using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Quadro_de_pendencias.Interfaces;

namespace Quadro_de_pendencias.Services
{
    public class PopupService : IPopupHelperService
    {
        private readonly IServiceProvider _serviceProvider;

        public PopupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult?> ShowAsync<TPopup, TResult>() where TPopup : Popup<TResult>
        {
            var popup = _serviceProvider.GetRequiredService<TPopup>();

            var page = Application.Current?.Windows.FirstOrDefault()?.Page;

            if (page is null)
                return default;

            var result = await page.ShowPopupAsync<TResult>(popup, new PopupOptions
            {
                Shape = null
            });

            if (result.WasDismissedByTappingOutsideOfPopup)
                return default;

            return result.Result;
        }
    }
}
