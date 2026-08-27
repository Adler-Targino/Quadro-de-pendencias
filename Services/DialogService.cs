using Quadro_de_pendencias.Interfaces;

namespace Quadro_de_pendencias.Services
{
    public class DialogService : IDialogService
    {
        public async Task<bool> ConfirmAsync(string title, string message, string accept, string cancel)
        {
            return await Shell.Current.DisplayAlertAsync(title, message, accept, cancel);
        }
    }
}
