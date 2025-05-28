using System.Windows.Input;
using Vued.BL.Facades;
using Vued.App.Utilities;

namespace Vued.App.ViewModels;

public class WatchlistEditViewModel : BindableObject
{

    private string _name;
    private string _description;
    private WatchlistItem _watchlistItem;
    private readonly WatchlistFacade _watchlistFacade;

    public WatchlistEditViewModel(WatchlistItem watchlistItem, IServiceProvider serviceProvider)
    {
        _watchlistItem = watchlistItem;
        _watchlistFacade = serviceProvider.GetRequiredService<WatchlistFacade>();
        _name = watchlistItem.Name;
        _description = watchlistItem.Description;

        EditCommand = new Command(async () => await OnEdit());
        DeleteCommand = new Command(async () => await OnDelete());
    }

    public ICommand EditCommand { get; }

    public async Task OnEdit()
    {
        try
        {
            var updatedWatchlistItem = new WatchlistItem
            {
                Id = _watchlistItem.Id,
                Name = Name,
                Description = Description
            };

            var currentWatchlistModel = await _watchlistFacade.GetByIdAsync(_watchlistItem.Id);
            if (currentWatchlistModel == null)
            {
                Logger.Debug(GetType(), "Watchlist item not found for update");
                throw new InvalidOperationException("Watchlist item not found for update.");
            }
            currentWatchlistModel.Name = updatedWatchlistItem.Name;
            currentWatchlistModel.Description = updatedWatchlistItem.Description;

            await _watchlistFacade.SaveAsync(currentWatchlistModel);

            await AlertDisplay.ShowAlertAsync("Success", "Watchlist updated successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error updating watchlist", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to updated watchlist: {ex.Message}", "OK");
        }
    }

    public ICommand DeleteCommand { get; }

    private async Task OnDelete()
    {
        try
        {
            await _watchlistFacade.DeleteAsync(_watchlistItem.Id);

            await AlertDisplay.ShowAlertAsync("Success", "Watchlist deleted successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error deleting watchlist", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to delete watchlist: {ex.Message}", "OK");
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged();
        }
    }
}