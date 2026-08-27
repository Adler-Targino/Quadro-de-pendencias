using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Models;
using System.Collections.ObjectModel;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class GroupPopupViewModel() : ObservableObject
    {
        [ObservableProperty]
        public partial string Name { get; set; } = string.Empty;

        public ObservableCollection<ColorOption> Colors { get; } =
        [
            new() { Color = Color.FromArgb("#6C63FF"), IsSelected = true },
            new() { Color = Color.FromArgb("#F48FB1") },
            new() { Color = Color.FromArgb("#800080") },
            new() { Color = Color.FromArgb("#81D4FA") },
            new() { Color = Color.FromArgb("#FF0000") },
            new() { Color = Color.FromArgb("#FFFF00") },
            new() { Color = Color.FromArgb("#32CD32") },
        ];

        public event EventHandler<GroupModel?>? RequestClose;

        [RelayCommand]
        private void SelectColor(ColorOption color)
        {
            foreach (var item in Colors)
                item.IsSelected = item == color;
        }

        [RelayCommand]
        private void Save()
        {
            var result = new GroupModel
            {
                Name = Name,
                Color = Colors.FirstOrDefault(x => x.IsSelected)!.Color.ToArgbHex(),
            };

            RequestClose?.Invoke(this, result);
        }

        [RelayCommand]
        private void Cancel()
        {
            RequestClose?.Invoke(this, null);
        }
    }
}
