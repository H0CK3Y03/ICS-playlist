using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.Views;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.BL.Services;
using Vued.BL.Queries;
using Vued.DAL.Repositories;
using Vued.DAL.Entities;

namespace Vued.App.ViewModels;

public class MainPageViewModel : BindableObject
{
    private readonly IServiceProvider _serviceProvider;
    private MediaFileFacade _mediaFileFacade;
    private string _searchQuery;
    private ObservableCollection<MediaItem> _mediaItems;
    private int _gridSpan;
    private readonly MovieService _movieService;
    private readonly IRepository<Movie> _movieRepository;
    private List<MediaItem> _allMediaItems = new();

    public MainPageViewModel(IServiceProvider serviceProvider)
    {
        System.Diagnostics.Debug.WriteLine("[AHHH]MainPageViewModel");
        _serviceProvider = serviceProvider;
        SettingsCommand = new Command(OnSettingsClicked);
        SearchCommand = new Command(OnSearch);
        //FilterCommand = new Command(OnFilterClicked);
        MediaSelectedCommand = new Command<MediaItem>(OnMediaSelected);
        MediaItems = new ObservableCollection<MediaItem>();
        GridSpan = 1; // Default span
    }
    public event EventHandler? FilterRequested;

    public async Task InitializeAsync()
    {
        await LoadMediaFiles();
    }
    public async Task LoadMediaFiles()
    {
        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediaFileFacade = scope.ServiceProvider.GetService<MediaFileFacade>();
                if (mediaFileFacade == null)
                {
                    System.Diagnostics.Debug.WriteLine("[]MediaFileFacade could not be resolved.");
                    throw new InvalidOperationException("[]MediaFileFacade could not be resolved.");
                }

                var mediaList = await mediaFileFacade.GetAllAsync();
                _allMediaItems = new List<MediaItem>();
                MediaItems.Clear();
                foreach (var media in mediaList)
                {
                    var item = new MediaItem
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
                    };

                    _allMediaItems.Add(item);
                    MediaItems.Add(item);
                }
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
            OnSearch(); 
        }
    }
    private void OnSearch()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            MediaItems = new ObservableCollection<MediaItem>(_allMediaItems);
            return;
        }

        var filtered = _allMediaItems
            .Where(item => item.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                           item.Description.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                           item.Director.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
            .ToList();

        MediaItems = new ObservableCollection<MediaItem>(filtered);
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

    public ICommand SettingsCommand { get; }
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

    private async void OnSettingsClicked()
    {
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlert("Settings", "Settings clicked!", "OK");
        }
    }

    private async void OnFilterClicked()
    {
        if (!string.IsNullOrEmpty(SearchQuery))
        {
            System.Diagnostics.Debug.WriteLine($"Search query: {SearchQuery}");
        }
    }

    private async void OnFilterClicked()
    {
        if (Application.Current?.MainPage != null)
        {
            var popup = _serviceProvider.GetService<FilterPopup>();
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var filters = (dynamic)result;
                System.Diagnostics.Debug.WriteLine($"Filters applied: Category={filters.Category}, SortOption={filters.SortOption}, MinReleaseYear={filters.MinReleaseYear}, OnlyFavourites={filters.OnlyFavourites}, IsDescending={filters.IsDescending}");
            }
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
