using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.App.Utilities;
using Vued.App.Views.Watchlist;

namespace Vued.App.ViewModels;

public record MediaItem : MediaFileModel
{
    /* Primitive Adapter for MediaFileModel */
    public string? ImageUrl { get; set;}
}
public record WatchlistItem : WatchlistModel
{
    /* Primitive Adapter for WatchlistModel */
} 

public class MainPageViewModel : BindableObject
{
    private readonly IServiceProvider _serviceProvider;
    private MediaFileFacade _mediaFileFacade;
    private WatchlistFacade _watchlistFacade;

    private ObservableCollection<MediaItem> _mediaItems;
    private ObservableCollection<WatchlistItem> _watchlistItems;
    private List<MediaItem> _allMediaItems = new();
    private List<WatchlistItem> _allWatchlistItems = new();

    private string _searchQuery;
    private int _gridSpan;

    private string _selectedCategory;
    private string _selectedSortOption;
    private double _minReleaseYear;
    private bool _onlyFavourites;
    private bool _isDescending;


    public MainPageViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _mediaFileFacade = serviceProvider.GetRequiredService<MediaFileFacade>();
        _watchlistFacade = serviceProvider.GetRequiredService<WatchlistFacade>();

        MediaItems = new ObservableCollection<MediaItem>();
        WatchlistItems = new ObservableCollection<WatchlistItem>();

        GridSpan = 1;
        SearchCommand = new Command(OnSearch);
        FilterCommand = new Command(OnFilterClicked);
        MediaSelectedCommand = new Command<MediaItem>(OnMediaSelected);
        WatchlistSelectedCommand = new Command<WatchlistItem>(OnWatchlistSelected);
    }

    public async Task InitializeAsync()
    {
        await LoadMediaFiles();
        await LoadWatchlists();
    }

    public async Task LoadWatchlists()
    {
        try
        {
            var watchList = await _watchlistFacade.GetAllAsync();
            var newItems = new ObservableCollection<WatchlistItem>();

            WatchlistItems.Clear();
            foreach (var media in watchList)
            {
                newItems.Add(new WatchlistItem 
                {
                    Id = media.Id,
                    Name = media.Name,
                    Description = media.Description
                });
            }

            _allWatchlistItems = newItems.ToList();
            foreach (var item in newItems)
            {
                WatchlistItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading watchlists", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to load watchlists: {ex.Message}", "OK");
        }
    }

    public async Task LoadMediaFiles()
    {
        try
        {
            var mediaList = await _mediaFileFacade.GetAllAsync();
            var newItems = new ObservableCollection<MediaItem>();

            MediaItems.Clear();
            foreach (var media in mediaList)
            {
                newItems.Add(new MediaItem
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
                    ImageUrl = media.URL
                });
            }

            _allMediaItems = newItems.ToList();
            foreach (var item in newItems)
            {
                MediaItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading media", ex);
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

    public ObservableCollection<WatchlistItem> WatchlistItems
    {
        get => _watchlistItems;
        set
        {
            _watchlistItems = value;
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

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged();
        }
    }

    public ICommand SearchCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand MediaSelectedCommand { get; }
    public ICommand WatchlistSelectedCommand { get; }

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

    private void OnSearch()
    {
        if (!string.IsNullOrEmpty(SearchQuery))
        {
            System.Diagnostics.Debug.WriteLine($"Search query: {SearchQuery}");
        }
    }

    private async void OnMediaSelected(MediaItem mediaItem)
    {
        if (mediaItem == null) return;
        var viewModel = new MediaDetailViewModel(mediaItem, _serviceProvider);
        var detailPage = new MediaDetailPage(viewModel);
        if (Application.Current != null && Application.Current.MainPage != null)
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
    }

    private async void OnWatchlistSelected(WatchlistItem watchlistItem)
    {
        if (watchlistItem == null) return;
        var viewModel = new WatchlistDetailViewModel(watchlistItem, _serviceProvider);
        var detailPage = new WatchlistDetail(viewModel, _serviceProvider);
        if (Application.Current != null && Application.Current.MainPage != null)
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
    }

    private async void OnFilterClicked()
    {
        var popup = _serviceProvider.GetService<FilterPopup>();
        if (Application.Current != null && Application.Current.MainPage != null && popup != null)
        {
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var filters = (dynamic)result;

                _selectedCategory = filters.Category;
                _selectedSortOption = filters.SortOption;
                _minReleaseYear = filters.MinReleaseYear;
                _onlyFavourites = filters.OnlyFavourites;
                _isDescending = filters.IsDescending;

                ApplyFilters();
            }
        }
    }

    // MOVE THIS TO BL AFTER SIMPLIFYING ARCHITECTURE
    private void ApplyFilters()
    {
        var filtered = _allMediaItems.AsEnumerable();

        if (!string.IsNullOrEmpty(_selectedCategory) && _selectedCategory != "All")
        {
            filtered = filtered.Where(item => item.GenreNames.Contains(_selectedCategory));
        }

        if (_onlyFavourites)
        {
            filtered = filtered.Where(item => item.Favourite);
        }

        if (_minReleaseYear > 1000)
        {
            filtered = filtered.Where(item => item.ReleaseDate >= _minReleaseYear);
        }

        switch (_selectedSortOption)
        {
            case "Alphabetical":
                filtered = _isDescending
                    ? filtered.OrderByDescending(item => item.Name)
                    : filtered.OrderBy(item => item.Name);
                break;
            case "Favourites":
                filtered = _isDescending
                    ? filtered.OrderByDescending(item => item.Favourite)
                    : filtered.OrderBy(item => item.Favourite);
                break;
            case "Ranking":
                filtered = _isDescending
                    ? filtered.OrderByDescending(item => item.Rating)
                    : filtered.OrderBy(item => item.Rating);
                break;
        }

        MediaItems.Clear();
        foreach (var item in filtered)
        {
            MediaItems.Add(item);
        }
    }
}
