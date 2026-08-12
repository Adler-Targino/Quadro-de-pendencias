using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.Views.Popups;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class MainPageViewModel(
        IBoardService service,
        IPopupHelperService popupService) : ObservableObject
    {
        private readonly IBoardService _service = service;
        private readonly IPopupHelperService _popupService = popupService;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Title))]
        [NotifyPropertyChangedFor(nameof(Description))]
        public partial BoardViewModel Board { get; set; }

        public ObservableCollection<BoardViewModel> Boards { get; } = [];

        public string Title => Board.Board.Title;
        public string Description => Board.Board.Description;


        public async Task InitializeAsync(Guid? boardId = null)
        {
            var boards = await _service.GetAllBoardsAsync();

            Boards.Clear();

            foreach (var board in boards)
            {
                Boards.Add(new BoardViewModel(board));
            }

            if (boardId == null)
                Board = Boards.First();
            else
                Board = Boards.First(x => x.Board.Id == boardId);
        }

        [RelayCommand]
        private async Task SelectBoard(Guid boardId)
        {
            await InitializeAsync(boardId);
        }

        [RelayCommand]
        private async Task OpenNewBoardModal()
        {
            var result = await _popupService.ShowAsync<NewBoardPopup, BoardModel?>();

            if (result is null)
                return;

            await _service.CreateBoardAsync(result);

            await InitializeAsync();
        }

        [RelayCommand]
        private async Task OpenNewGroupModal()
        {
            var result = await _popupService.ShowAsync<NewGroupPopup, GroupModel?>();

            if (result is null)
                return;

            result.BoardId = Board.Board.Id;

            await _service.CreateGroupAsync(result);

            Board.Groups.Add(new GroupViewModel(result));
        }

        [RelayCommand]
        private async Task OpenNewCardModal(Guid groupId)
        {
            var result = await _popupService.ShowAsync<NewCardPopup, CardModel?>();

            if (result is null)
                return;

            result.GroupId = groupId;

            await _service.CreateCardAsync(result);

            var group = Board.Groups
                             .FirstOrDefault(x => x.Group.Id == groupId);

            if (group is null)
                return;

            group.Cards.Add(result);
        }
    }
}
