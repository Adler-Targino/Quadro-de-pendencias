using Quadro_de_pendencias.Interfaces;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly BoardViewModel _viewModel;

        public MainPage(BoardViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.InitializeAsync();
        }
    }
}
