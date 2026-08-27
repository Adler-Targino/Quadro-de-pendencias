using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.Models.Enums;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class CardPopupViewModel() : ObservableObject
    {
        private Guid? _cardId;
        private Guid _groupId;

        [ObservableProperty]
        public partial string Title { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Description { get; set; } = string.Empty;

        [ObservableProperty]
        public partial DateTime? DueDate { get; set; }

        public IEnumerable<CardPriority> CardPriorityEnum => Enum.GetValues<CardPriority>();

        [ObservableProperty]
        public partial CardPriority Priority { get; set; } = CardPriority.Normal;

        [ObservableProperty]
        public partial bool IsEditing { get; set; }

        public event EventHandler<CardModel?>? RequestClose;

        public void LoadCard(CardModel card)
        {
            _cardId = card.Id;
            _groupId = card.GroupId;

            Title = card.Title;
            Description = card.Description;
            DueDate = card.DueDate;
            Priority = card.Priority;

            IsEditing = true;
        }

        [RelayCommand]
        private void Save()
        {
            var result = new CardModel
            {
                Id = _cardId ?? Guid.NewGuid(),
                GroupId = _groupId,
                Title = Title,
                Description = Description,
                DueDate = DueDate,
                Priority = Priority,
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
