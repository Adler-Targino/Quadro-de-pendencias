using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.Models.Enums;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class NewCardPopupViewModel() : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Description { get; set; } = string.Empty;

        [ObservableProperty]
        public partial DateTime? DueDate { get; set; }

        public IEnumerable<CardPriority> CardPriorityEnum => Enum.GetValues<CardPriority>();

        [ObservableProperty]
        public partial CardPriority Priority { get; set; } = CardPriority.Normal;

        public event EventHandler<CardModel?>? RequestClose;

        public async Task InitializeAsync()
        {
        }

        [RelayCommand]
        private void Save()
        {
            var result = new CardModel
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
