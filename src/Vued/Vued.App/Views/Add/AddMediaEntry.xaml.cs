using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.ViewModels;

namespace Vued.App.Views.Add;

public partial class AddMediaEntry : Popup
{
    public AddMediaEntry(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        BindingContext = new AddMediaEntryViewModel(serviceProvider);
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close(); // Close the popup without saving
    }
}