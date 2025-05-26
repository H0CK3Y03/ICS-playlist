using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.App.ViewModels;

public class MainPageViewModel : BindableObject
{
    private readonly IServiceProvider _serviceProvider;
    private MediaFileFacade _mediaFileFacade;
    private ObservableCollection<MediaItem> _mediaItems;
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
        MediaItems = new ObservableCollection<MediaItem>();
        GridSpan = 1;

        SearchCommand = new Command(OnSearch);
        FilterCommand = new Command(OnFilterClicked);
        MediaSelectedCommand = new Command<MediaItem>(OnMediaSelected);
    }

    public async Task InitializeAsync()
    {
        await LoadMediaFiles();
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
                    GenreNames = media.GenreNames
                });
            }

            foreach (var item in newItems)
            {
                MediaItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[]Error loading media: {ex.Message}\nStackTrace: {ex.StackTrace}");
            await Application.Current.MainPage.DisplayAlert("[]Error", $"Failed to load media: {ex.Message}", "OK");
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

    public ICommand SearchCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand MediaSelectedCommand { get; }

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

    private async void OnFilterClicked()
    {
        var popup = _serviceProvider.GetService<FilterPopup>();
        var result = await Application.Current.MainPage.ShowPopupAsync(popup);
        if (result != null)
        {
            var filters = (dynamic)result;
            System.Diagnostics.Debug.WriteLine($"Filters applied: Category={filters.Category}, SortOption={filters.SortOption}, MinReleaseYear={filters.MinReleaseYear}, OnlyFavourites={filters.OnlyFavourites}, IsDescending={filters.IsDescending}");
        }
    }

    private async void OnMediaSelected(MediaItem mediaItem)
    {
        if (mediaItem == null) return;
        var viewModel = new MediaDetailViewModel(mediaItem, _serviceProvider);
        var detailPage = new MediaDetailPage(viewModel);
        await Application.Current.MainPage.Navigation.PushAsync(detailPage);
    }
}

public class MediaItem
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required MediaStatus Status { get; set; }
    public required string Description { get; set; }
    public required int Duration { get; set; }
    public required string Director { get; set; }
    public required int ReleaseDate { get; set; }
    public required string Rating { get; set; }
    public string? URL { get; set; }
    public bool Favourite { get; set; }
    public MediaType MediaType { get; set; }
    public List<string> GenreNames { get; set; } = new List<string>();
}
