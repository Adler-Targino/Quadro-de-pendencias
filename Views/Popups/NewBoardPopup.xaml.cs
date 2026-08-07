using CommunityToolkit.Maui.Views;
using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Views.Popups;

public partial class NewBoardPopup : Popup<BoardModel?>
{
	public NewBoardPopup(NewBoardPopupViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
        viewModel.RequestClose += OnRequestClose;
    }

    private async void OnRequestClose(object? sender, BoardModel? result)
    {
        if (BindingContext is NewBoardPopupViewModel vm)
            vm.RequestClose -= OnRequestClose;

        await CloseAsync(result);
    }
}