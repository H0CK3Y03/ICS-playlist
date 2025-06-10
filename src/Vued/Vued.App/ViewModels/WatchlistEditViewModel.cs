using System.Windows.Input;
using Vued.BL.Facades;
using Vued.App.Utilities;
using System.Collections.ObjectModel;

namespace Vued.App.ViewModels;

public class MediaCheckbox : BindableObject
{
    private bool _isChecked;

    public int Id { get; set; }
    public string Name { get; set; }

    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            _isChecked = value;
            OnPropertyChanged();
        }
    }
}

public class WatchlistEditViewModel : BindableObject
{
    private string _name;
    private string _description;
    private WatchlistItem _watchlistItem;
    private readonly WatchlistFacade _watchlistFacade;
    private readonly MediaFileFacade _mediaFileFacade;
    private ObservableCollection<MediaCheckbox> _mediaList;

    public WatchlistEditViewModel(WatchlistItem watchlistItem, IServiceProvider serviceProvider)
    {
        _watchlistItem = watchlistItem;
        _watchlistFacade = serviceProvider.GetRequiredService<WatchlistFacade>();
        _mediaFileFacade = serviceProvider.GetRequiredService<MediaFileFacade>();
        _name = watchlistItem.Name;
        _description = watchlistItem.Description;

        EditCommand = new Command(async () => await OnEdit());
        DeleteCommand = new Command(async () => await OnDelete());
        LoadMediaAsync().GetAwaiter().GetResult();
    }

    public ICommand EditCommand { get; }

    public async Task OnEdit()
    {
        try
        {
            // Update watchlist details
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

            var currentMediaIds = await _watchlistFacade.GetMediaIdsForWatchlistAsync(_watchlistItem.Id);
            foreach (var media in MediaList)
            {
                if (media.IsChecked && !currentMediaIds.Contains(media.Id))
                {
                    await _watchlistFacade.AddMediaToWatchlistAsync(_watchlistItem.Id, media.Id);
                }
                else if (!media.IsChecked && currentMediaIds.Contains(media.Id))
                {
                    await _watchlistFacade.RemoveMediaFromWatchlistAsync(_watchlistItem.Id, media.Id);
                }
            }

            await AlertDisplay.ShowAlertAsync("Success", "Watchlist updated successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error updating watchlist", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to update watchlist: {ex.Message}", "OK");
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

    public ObservableCollection<MediaCheckbox> MediaList
    {
        get => _mediaList;
        set
        {
            _mediaList = value;
            OnPropertyChanged();
        }
    }

    private async Task LoadMediaAsync()
    {
        try
        {
            var allMedia = await _mediaFileFacade.GetAllAsync();
            var watchlistMediaIds = await _watchlistFacade.GetMediaIdsForWatchlistAsync(_watchlistItem.Id);

            MediaList = new ObservableCollection<MediaCheckbox>(
                allMedia.Select(m => new MediaCheckbox
                {
                    Id = m.Id,
                    Name = m.Name,
                    IsChecked = watchlistMediaIds.Contains(m.Id)
                }));
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading media", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to load media: {ex.Message}", "OK");
        }
    }
}