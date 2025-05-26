using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;

namespace Vued.App.Views.MediaFile;

public partial class MediaEditPopup : Popup
{
    public MediaEditPopup(MediaEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close();
    }
}
