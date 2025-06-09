using System.Collections.ObjectModel;
using System.Windows.Input;
using Vued.BL.Facades;
using Vued.App.Utilities;
using Vued.App.Views.MediaFile;
using System.Runtime.CompilerServices;
using Vued.App.Views.Watchlist;
using CommunityToolkit.Maui.Views;
using Windows.UI.Popups;

namespace Vued.App.ViewModels;

public class WatchlistDetailViewModel : BindableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly MediaFileFacade _mediaFileFacade;
    private readonly WatchlistItem _watchlistItem;

    private ObservableCollection<MediaItem> _mediaItems;
    private int _gridSpan;
    private string _watchlistName;
    private string _watchlistDescription;

    public WatchlistDetailViewModel(WatchlistItem watchlistItem, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _mediaFileFacade = serviceProvider.GetRequiredService<MediaFileFacade>();
        _watchlistItem = watchlistItem;

        MediaItems = new ObservableCollection<MediaItem>();
        GridSpan = 1;
        WatchlistName = watchlistItem.Name;
        WatchlistDescription = watchlistItem.Description;

        GoBackCommand = new Command(OnGoBack);
        EditCommand = new Command(OnEdit);
        MediaSelectedCommand = new Command<MediaItem>(OnMediaSelected);
    }

    public async Task InitializeAsync()
    {
        await LoadMediaItems();
    }

    private async Task LoadMediaItems()
    {
        try
        {
            var mediaList = await _mediaFileFacade.GetAllAsync();

            MediaItems.Clear();

            if (_watchlistItem.Id == 1) 
            {
                foreach (var media in mediaList.Where(m => m.Favourite))
                {
                    MediaItems.Add(new MediaItem
                    {
                        Id = media.Id,
                        Name = media.Name,
                        Status = media.Status,
                        Description = media.Description,
                        Duration = media.Duration,
                        Director = media.Director,
                        ReleaseDate = media.ReleaseDate,
                        Rating = media.Rating,
                        Favourite = media.Favourite,
                        MediaType = media.MediaType,
                        GenreNames = media.GenreNames,
                        URL = media.URL,
                        ImageUrl = media.URL,
                        Review = media.Review
                    });
                }
            }
            else
            {
                var selectedIds = await _serviceProvider
                    .GetRequiredService<WatchlistFacade>()
                    .GetMediaIdsForWatchlistAsync(_watchlistItem.Id);

                foreach (var media in mediaList.Where(m => selectedIds.Contains(m.Id)))
                {
                    MediaItems.Add(new MediaItem
                    {
                        Id = media.Id,
                        Name = media.Name,
                        Status = media.Status,
                        Description = media.Description,
                        Duration = media.Duration,
                        Director = media.Director,
                        ReleaseDate = media.ReleaseDate,
                        Rating = media.Rating,
                        Favourite = media.Favourite,
                        MediaType = media.MediaType,
                        GenreNames = media.GenreNames,
                        URL = media.URL,
                        ImageUrl = media.URL,
                        Review = media.Review
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading media items", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to load media: {ex.Message}", "OK");
        }
    }


    public ObservableCollection<MediaItem> MediaItems
    {
        get => _mediaItems;
        set
        {
            _mediaItems = value;
            OnPropertyChanged();
        }
    }

    public int GridSpan
    {
        get => _gridSpan;
        set
        {
            _gridSpan = value;
            OnPropertyChanged();
        }
    }

    public string WatchlistName
    {
        get => _watchlistName;
        set
        {
            _watchlistName = value;
            OnPropertyChanged();
        }
    }

    public string WatchlistDescription
    {
        get => _watchlistDescription;
        set
        {
            _watchlistDescription = value;
            OnPropertyChanged();
        }
    }

    public ICommand MediaSelectedCommand { get; }
    public ICommand AddMediaCommand { get; }

    public void UpdateGridSpan(double windowWidth)
    {
        const double itemWidth = 190;
        const double horizontalSpacing = 0;
        const double margin = 0;
        const int minSpan = 1;
        const int maxSpan = 99;

        double availableWidth = windowWidth - margin;
        int calculatedSpan = (int)Math.Floor(availableWidth / (itemWidth + horizontalSpacing));
        GridSpan = Math.Clamp(calculatedSpan, minSpan, maxSpan);
    }

    private async void OnMediaSelected(MediaItem mediaItem)
    {
        if (mediaItem == null) return;
        var viewModel = new MediaDetailViewModel(mediaItem, _serviceProvider);
        var detailPage = new MediaDetailPage(viewModel);
        await Application.Current.MainPage.Navigation.PushAsync(detailPage);
    }

    public ICommand GoBackCommand { get; }
    public ICommand EditCommand { get; }

    private async void OnGoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async void OnEdit()
    {
        if (Application.Current?.MainPage != null)
        {
            var viewModel = new WatchlistEditViewModel(_watchlistItem, _serviceProvider);
            var popup = new WatchlistEditPopup(viewModel);
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var updatedWatchlist = (dynamic)result;

                WatchlistName = updatedWatchlist.Name;
                WatchlistDescription = updatedWatchlist.Description;

                Logger.Debug(GetType(), $"Updated watchlist: {WatchlistName}");
            }
        }
    }
}
