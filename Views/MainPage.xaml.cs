using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
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
