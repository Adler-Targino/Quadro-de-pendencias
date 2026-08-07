using CommunityToolkit.Maui.Views;

namespace Quadro_de_pendencias.Interfaces
{
    public interface IPopupHelperService
    {
        Task<TResult?> ShowAsync<TPopup, TResult>() where TPopup : Popup<TResult>;
    }
}
