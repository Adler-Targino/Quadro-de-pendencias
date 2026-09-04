using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class GroupViewModel : ObservableObject
    {
        private readonly IDragDropService _dragDropService;
        private readonly IBoardService _boardService;

        [ObservableProperty]
        public partial GroupModel Group { get; set; }

        public ObservableCollection<CardViewModel> Cards { get; } = [];
        public ObservableCollection<CardViewModel> VisibleCards { get; } = [];

        public bool HideCompleted { get; set; }
        public string CardCompletionPercentage
        {
            get
            {
                if (Cards.Count == 0)
                    return "0%";

                var completed = Cards.Count(x => x.IsChecked);
                var percentage = (double)completed / Cards.Count * 100;

                return $"{percentage:0}%";
            }
        }

        public GroupViewModel(
            IDragDropService dragDropService,
            IBoardService boardService,
            GroupModel group)
        {
            _dragDropService = dragDropService;
            _boardService = boardService;
            
            Group = group;

            foreach (var card in Group.Cards)
            {
                var cardViewModel = new CardViewModel(boardService, card);

                cardViewModel.CheckedChanged += OnCardCheckedChanged;

                Cards.Add(cardViewModel);
            }
        }

        [RelayCommand]
        private void CardDragStarting(CardViewModel card)
        {
            _dragDropService.DraggedCard = card;
            _dragDropService.SourceGroup = this;
        }

        [RelayCommand]
        private void CardDrop(CardViewModel targetCard)
        {
            var draggedCard = _dragDropService.DraggedCard;
            var sourceGroup = _dragDropService.SourceGroup;

            if (draggedCard is null || sourceGroup is null)
                return;

            if (ReferenceEquals(sourceGroup, this)) //Mesmo grupo
            {
                if (!ReferenceEquals(draggedCard, targetCard) && targetCard is not null)
                {
                    int source = Cards.IndexOf(draggedCard);
                    int target = Cards.IndexOf(targetCard);

                    if (source >= 0 && target >= 0)
                        Cards.Move(source, target);
                }
            }
            else
            {
                sourceGroup.Cards.Remove(draggedCard);

                // Insere no grupo de destino, na posição do alvo (ou no fim, se soltou na área vazia)
                int targetIndex = targetCard is not null ? Cards.IndexOf(targetCard) : Cards.Count;
                if (targetIndex < 0) targetIndex = Cards.Count;

                Cards.Insert(targetIndex, draggedCard);

                draggedCard.Card.GroupId = this.Group.Id;

                // opcional: salvar no banco/API aqui, ou disparar um evento/command de persistência
            }

            _dragDropService.Reset();
        }

        private void OnCardCheckedChanged(CardViewModel card)
        {
            var index = Cards.IndexOf(card);

            if (index == -1)
                return;

            if (card.IsChecked)
            {
                Cards.RemoveAt(index);
                Cards.Add(card);
            }
            else
            {
                Cards.Move(index, 0);
            }

            OnPropertyChanged(nameof(CardCompletionPercentage));
            UpdateVisibleCards();
        }

        public void UpdateVisibleCards()
        {
            VisibleCards.Clear();

            foreach (var card in Cards)
            {
                if (!HideCompleted || !card.IsChecked)
                    VisibleCards.Add(card);
            }
        }
    }
}
