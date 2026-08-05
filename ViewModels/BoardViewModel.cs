using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.Models;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class BoardViewModel(IBoardService service) : ObservableObject
    {
        [ObservableProperty]
        public partial BoardModel Board { get; set; }
        public ObservableCollection<CardGroupViewModel> Groups { get; } = [];

        public async Task InitializeAsync()
        {
            Board = await service.GetBoardAsync();
            
            Groups.Clear();

            foreach (var group in Board.Groups)
            {
                Groups.Add(new CardGroupViewModel(Board, group));
            }
        }
    }
}
