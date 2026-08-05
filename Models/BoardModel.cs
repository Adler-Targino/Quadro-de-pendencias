using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.Models
{
    public partial class BoardModel : ObservableObject
    {
        [ObservableProperty]
        public partial Guid Id { get; set; } = Guid.NewGuid();

        [ObservableProperty]
        public partial string Title { get; set; } = "Meu quadro de pendências";

        [ObservableProperty]
        public partial string Description { get; set; } = "Descrição do quadro";

        public ObservableCollection<CardGroupModel> Groups { get; } = [];
        public ObservableCollection<CardModel> Cards { get; } = [];
    }
}
