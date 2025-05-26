using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.ViewModels;
using Vued.BL.Facades;
using Vued.BL.Models;

namespace Vued.App.Views.Add;

public partial class AddMediaEntry : Popup
{
    public AddMediaEntry(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        var genreFacade = serviceProvider.GetRequiredService<GenreFacade>();
        var mediaFileFacade = serviceProvider.GetRequiredService<MediaFileFacade>();

        BindingContext = new AddMediaEntryViewModel(genreFacade, mediaFileFacade, OnSaveComplete);
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
