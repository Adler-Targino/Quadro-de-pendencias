using CommunityToolkit.Maui.Views;
using Quadro_de_pendencias.Models;
using Quadro_de_pendencias.ViewModels;

namespace Quadro_de_pendencias.Views.Popups;

public partial class NewGroupPopup : Popup<GroupModel?>
{
    public NewGroupPopup(NewGroupPopupViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
        viewModel.RequestClose += OnRequestClose;
    }

    private async void OnRequestClose(object? sender, GroupModel? result)
    {
        if (BindingContext is NewGroupPopupViewModel vm)
            vm.RequestClose -= OnRequestClose;

        await CloseAsync(result);
    }
}