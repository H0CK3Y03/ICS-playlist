using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Vued.App.Views.Add;
using Vued.App.Utilities;

namespace Vued.App.ViewModels;

public class AddPopupViewModel
{
    private readonly IServiceProvider _serviceProvider;
    private readonly MainPageViewModel _mainPageViewModel;

    public AddPopupViewModel(IServiceProvider serviceProvider, MainPageViewModel mainPageViewModel)
    {
        _mainPageViewModel = mainPageViewModel;
        _serviceProvider = serviceProvider;
        AddMediaEntryCommand = new Command(async () => await OnAddMediaEntry());
        AddWatchlistCommand = new Command(async () => await OnAddWatchlist());
    }

    public ICommand AddMediaEntryCommand { get; }
    public ICommand AddWatchlistCommand { get; }

    private async Task OnAddMediaEntry()
    {
        try
        {
            var popup = new AddMediaEntry(_serviceProvider);
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            await _mainPageViewModel.LoadMediaFiles();
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error creating media", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to create new media: {ex.Message}", "OK");
        }
    }

    private async Task OnAddWatchlist()
    {
        try
        {
            var popup = new AddWatchlist(_serviceProvider);
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            await _mainPageViewModel.LoadWatchlists();
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error creating watchlist", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to create new watchlist: {ex.Message}", "OK");
        }
    }
}