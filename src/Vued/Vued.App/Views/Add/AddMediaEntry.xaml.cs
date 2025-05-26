using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.ViewModels;
using Vued.BL.Models;

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
        Close(); // Close the popup without saving
    }
}