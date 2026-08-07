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


        public async Task InitializeAsync()
        {
            var boards = await _service.GetAllBoardsAsync();

            Boards.Clear();

            foreach (var board in boards)
            {
                Boards.Add(new BoardViewModel(board));
            }

            Board = Boards.FirstOrDefault();
        }

        [RelayCommand]
        private async Task OpenNewGroupModal()
        {
            var result = await _popupService.ShowAsync<NewGroupPopup, GroupModel>();

            if (result is null)
                return;

            await _service.CreateGroupAsync(result);
        }

        [RelayCommand]
        private async Task OpenNewBoardModal()
        {
            var result = await _popupService.ShowAsync<NewBoardPopup, BoardModel>();

            if (result is null)
                return;

            await _service.CreateBoardAsync(result);
        }
    }
}
