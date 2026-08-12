using CommunityToolkit.Maui.Views;
using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Views.Popups;

public partial class NewCardPopup : Popup<CardModel?>
{
	public NewCardPopup(NewCardPopupViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
        viewModel.RequestClose += OnRequestClose;
    }

    private async void OnRequestClose(object? sender, CardModel? result)
    {
        if (BindingContext is NewCardPopupViewModel vm)
            vm.RequestClose -= OnRequestClose;

        await CloseAsync(result);
    }
}