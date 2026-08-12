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

        public GroupViewModel(GroupModel group)
        {
            Group = group;

            foreach (var card in Group.Cards)
            {
                Cards.Add(card);
            }
        }
    }
}
