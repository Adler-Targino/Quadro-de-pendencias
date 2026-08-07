using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.ViewModels
{
    public partial class NewGroupPopupViewModel() : ObservableObject
    {
        [ObservableProperty]
        public partial string Name { get; set; } = string.Empty;

        public event EventHandler<GroupModel?>? RequestClose;

        public async Task InitializeAsync()
        {
        }

        [RelayCommand]
        private void Save()
        {
            var result = new GroupModel
            {
                Name = Name
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
