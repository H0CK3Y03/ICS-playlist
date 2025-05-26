using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;

namespace Vued.App.Views.Add;

public partial class AddMediaEntry : Popup
{
    public AddMediaEntry(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        BindingContext = new AddMediaEntryViewModel(serviceProvider, OnSaveComplete);
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
