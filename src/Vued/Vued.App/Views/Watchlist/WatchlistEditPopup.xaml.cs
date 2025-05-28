using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;

namespace Vued.App.Views.Watchlist;

public partial class WatchlistEditPopup : Popup
{
    public WatchlistEditPopup(WatchlistEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close();
    }
}

