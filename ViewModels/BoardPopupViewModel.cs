using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class BoardPopupViewModel() : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Description { get; set; } = string.Empty;

        public event EventHandler<BoardModel?>? RequestClose;

        public async Task InitializeAsync()
        {
        }

        [RelayCommand]
        private void Save()
        {
            var result = new BoardModel
            {
                Title = Title,
                Description = Description,
            };

            RequestClose?.Invoke(this, result);
        }

        [RelayCommand]
        private void Cancel()
        {
            RequestClose?.Invoke(this, null);
        }
    }
}
