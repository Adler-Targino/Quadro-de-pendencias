using CommunityToolkit.Mvvm.ComponentModel;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class CardViewModel : ObservableObject
    {
        private readonly IBoardService _service;

        [ObservableProperty]
        public partial CardModel Card { get; set; }

        [ObservableProperty]
        public partial bool IsChecked { get; set; }
        
        public event Action<CardViewModel>? CheckedChanged;
        
        private bool _isInitialized;

        public CardViewModel(
            IBoardService service,
            CardModel card)
        {
            Card = card;
            IsChecked = Card.IsCompleted;

            _service = service;

            _isInitialized = true;
        }

        async partial void OnIsCheckedChanged(bool value)
        {
            if (!_isInitialized)
                return;

            Card.IsCompleted = value;
            await _service.UpdateCardCompletionAsync(Card);

            CheckedChanged?.Invoke(this);
        }
    }
}
