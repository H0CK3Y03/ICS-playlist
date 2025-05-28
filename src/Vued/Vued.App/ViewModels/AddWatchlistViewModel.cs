using System.Windows.Input;
using Vued.App.Utilities;
using Vued.BL.Facades;
using Vued.BL.Models;

namespace Vued.App.ViewModels;

public class AddWatchlistViewModel
{
    private readonly Action _onSaveComplete;
    private readonly WatchlistFacade _watchlistFacade;

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICommand AddCommand { get; }

    public AddWatchlistViewModel(IServiceProvider serviceProvider, Action onSaveComplete)
    {
        _onSaveComplete = onSaveComplete;
        _watchlistFacade = serviceProvider.GetRequiredService<WatchlistFacade>();

        AddCommand = new Command(async () => await OnAddAsync());
    }

    private async Task OnAddAsync()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                await AlertDisplay.ShowAlertAsync("Error", "Watchlist title is required.", "OK");
                return;
            }

            var watchlistModel = new WatchlistModel
            {
                Id = 0,
                Name = Name,
                Description = Description,
            };

            await _watchlistFacade.SaveAsync(watchlistModel);

            Logger.Debug(GetType(), $"New watchlist added with ID {watchlistModel.Id}: {watchlistModel.Name}");
            await AlertDisplay.ShowAlertAsync("Success", "Watchlist added successfully", "OK");
            _onSaveComplete?.Invoke();
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error creating watchlist", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to create new watchlist: {ex.Message}", "OK");
        }
    }
}

