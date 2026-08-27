using CommunityToolkit.Mvvm.ComponentModel;

namespace Quadro_de_pendencias.Models
{
    public partial class ColorOption : ObservableObject
    {
        [ObservableProperty]
        private Color color;

        [ObservableProperty]
        private bool isSelected;
    }
}
