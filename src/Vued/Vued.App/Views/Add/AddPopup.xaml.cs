using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;

namespace Vued.App.Views.Add;

public partial class AddPopup : Popup
{

    public AddPopup()
    {
        InitializeComponent();
    }

    private void OnAddMediaEntryClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void OnAddWatchlistClicked(object sender, EventArgs e)
    {
        // TODO: Implement watchlist creation (NOT IMPORTANT)
        Close();
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close();
    }
}