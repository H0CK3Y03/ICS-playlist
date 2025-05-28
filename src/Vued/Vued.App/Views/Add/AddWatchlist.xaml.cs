using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;

namespace Vued.App.Views.Add;

public partial class AddWatchlist : Popup
{
    public AddWatchlist(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        BindingContext = new AddWatchlistViewModel(serviceProvider, OnSaveComplete);
    }

    private void OnSaveComplete()
    {
        Close();
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close();
    }
}