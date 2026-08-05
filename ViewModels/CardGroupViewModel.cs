using CommunityToolkit.Mvvm.ComponentModel;
using Quadro_de_pendencias.Models;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class CardGroupViewModel : ObservableObject
    {
        private readonly BoardModel _board;

        public CardGroupModel Group { get; }

        public string Name => Group.Name;

        public string Color => Group.Color;

        public ObservableCollection<CardModel> Cards { get; } = [];

        public CardGroupViewModel(BoardModel board, CardGroupModel group)
        {
            _board = board;
            Group = group;

            foreach (var card in board.Cards.Where(c => c.GroupId == group.Id))
            {
                Cards.Add(card);
            }
        }
    }
}
