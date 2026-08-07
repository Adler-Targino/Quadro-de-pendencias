using CommunityToolkit.Mvvm.ComponentModel;
using Quadro_de_pendencias.Models;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class GroupViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial GroupModel Group { get; set; }

        public ObservableCollection<CardModel> Cards { get; } = [];

        public GroupViewModel(BoardModel board, GroupModel group)
        {
            Group = group;

            foreach (var card in board.Cards.Where(c => c.GroupId == group.Id))
            {
                Cards.Add(card);
            }
        }
    }
}
