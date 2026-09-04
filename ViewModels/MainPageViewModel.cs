using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.Views;
using Quadro_de_pendencias.Views.Popups;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class MainPageViewModel(
        IBoardService boardService,
        IDialogService dialogService,
        IDragDropService dragDropService,
        IPopupHelperService popupService) : ObservableObject
    {
        private readonly IBoardService _boardService = boardService;
        private readonly IDialogService _dialogService = dialogService;
        private readonly IDragDropService _dragService = dragDropService;
        private readonly IPopupHelperService _popupService = popupService;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Title))]
        [NotifyPropertyChangedFor(nameof(Description))]
        public partial BoardViewModel Board { get; set; }

        public ObservableCollection<BoardViewModel> Boards { get; } = [];

        [ObservableProperty]
        public partial bool IsEditingTitle { get; set; }
        [ObservableProperty]
        public partial string Title { get; set; }
        [ObservableProperty]
        public partial bool IsEditingDescription { get; set; }
        [ObservableProperty]
        public partial string Description { get; set; }
        [ObservableProperty]
        public partial bool HideCompleted { get; set; }

        public async Task InitializeAsync(Guid? boardId = null)
        {
            var boards = await _boardService.GetAllBoardsAsync();

            Boards.Clear();

            foreach (var board in boards)
            {
                Boards.Add(new BoardViewModel(_dragService, _boardService, board));
            }

            if (boardId != null)
                Board = Boards.First(x => x.Board.Id == boardId);
            else if(Board == null)
                Board = Boards.First();

            OnHideCompletedChanged(false);

            Title = Board.Board.Title;
            Description = Board.Board.Description;
        }

        [RelayCommand]
        private async Task SelectBoard(Guid boardId)
        {
            await InitializeAsync(boardId);
        }

        [RelayCommand]
        private async Task EditBoardTitle()
        {
            IsEditingTitle = true;
        }

        [RelayCommand]
        private async Task SaveBoardTitle()
        {
            IsEditingTitle = false;

            Board.Board.Title = Title;

            await _boardService.UpdateBoardAsync(Board.Board);
        }

        [RelayCommand]
        private async Task EditBoardDescription()
        {
            IsEditingDescription = true;
        }

        [RelayCommand]
        private async Task SaveBoardDescription()
        {
            IsEditingDescription = false;

            Board.Board.Description = Description;

            await _boardService.UpdateBoardAsync(Board.Board);
        }

        [RelayCommand]
        private async Task OpenNewBoardModal()
        {
            var result = await _popupService.ShowAsync<NewBoardPopup, BoardModel?>();

            if (result is null)
                return;

            await _boardService.CreateBoardAsync(result);

            await InitializeAsync(result.Id);
        }

        [RelayCommand]
        private async Task DeleteBoard(BoardViewModel board)
        {
            bool confirmation = await _dialogService.ConfirmAsync(
                "Excluir quadro",
                $"Deseja realmente excluir o quadro \"{board.Board.Title}\"?");

            if (!confirmation)
                return;

            await _boardService.RemoveBoardAsync(board.Board);

            Boards.Remove(board);
            Board = null;
            await InitializeAsync(Boards.FirstOrDefault()?.Board.Id);
        }

        [RelayCommand]
        private async Task OpenNewGroupModal()
        {
            var result = await _popupService.ShowAsync<NewGroupPopup, GroupModel?>();

            if (result is null)
                return;

            result.BoardId = Board.Board.Id;

            await _boardService.CreateGroupAsync(result);

            Board.Groups.Add(new GroupViewModel(_dragService, _boardService, result));
        }

        [RelayCommand]
        private async Task DeleteGroup(GroupViewModel group)
        {
            bool confirmation = await _dialogService.ConfirmAsync(
                "Excluir grupo",
                $"Deseja realmente excluir o grupo \"{group.Group.Name}\"?");

            if (!confirmation)
                return;

            await _boardService.RemoveGroupAsync(group.Group);

            Board.Groups.Remove(group);
        }

        [RelayCommand]
        private async Task OpenNewCardModal(Guid groupId)
        {
            var result = await _popupService.ShowAsync<NewCardPopup, CardModel?>();

            if (result is null)
                return;

            result.GroupId = groupId;

            await _boardService.CreateCardAsync(result);

            var group = Board.Groups
                             .FirstOrDefault(x => x.Group.Id == groupId);

            if (group is null)
                return;

            group.Cards.Add(new CardViewModel(_boardService, result));
        }

        [RelayCommand]
        private async Task OpenEditCardModal(CardViewModel card)
        {
            var result = await _popupService.ShowAsync<NewCardPopup, CardModel?>(popup =>
            {
                if (popup.BindingContext is CardPopupViewModel vm)
                    vm.LoadCard(card.Card);
            });

            if (result is null)
                return;

            await _boardService.UpdateCardAsync(result);

            var group = Board.Groups.FirstOrDefault(x => x.Group.Id == result.GroupId);

            if (group is null)
                return;

            var index = group.Cards.IndexOf(card);
            if (index >= 0)
                group.Cards[index] = new CardViewModel(_boardService, result);
        }

        [RelayCommand]
        private async Task DeleteCard(CardViewModel card)
        {
            bool confirmation = await _dialogService.ConfirmAsync(
                "Excluir card",
                $"Deseja realmente excluir o card \"{card.Card.Title}\"?");

            if (!confirmation)
                return;
            
            await _boardService.RemoveCardAsync(card.Card);

            var group = Board.Groups
                             .FirstOrDefault(x => x.Group.Id == card.Card.GroupId);

            if (group is null)
                return;

            group.Cards.Remove(card);
        }

        partial void OnHideCompletedChanged(bool value)
        {
            foreach (var group in Board.Groups)
            {
                group.HideCompleted = value;
                group.UpdateVisibleCards();
            }
        }
    }
}
