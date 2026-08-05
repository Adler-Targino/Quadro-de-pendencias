using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.Models
{
    public partial class CardGroupModel : ObservableObject
    {
        [ObservableProperty]
        public partial Guid Id { get; set; } = Guid.NewGuid();

        [ObservableProperty]
        public partial string Name { get; set; } = "";

        // Cor da faixa superior da coluna
        [ObservableProperty]
        public partial string Color { get; set; } = "#6C63FF";

        [ObservableProperty]
        public partial int Order { get; set; }
    }
}
