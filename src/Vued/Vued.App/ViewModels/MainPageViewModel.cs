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


    public MainPageViewModel(IServiceProvider serviceProvider)
    public MainPageViewModel(IServiceProvider serviceProvider /*MediaFileFacade mediaFileFacade*/)
    {
        System.Diagnostics.Debug.WriteLine("[AHHH]MainPageViewModel");
        _serviceProvider = serviceProvider;
        _movieService = _movieService;
        _movieRepository = _movieRepository;
        //_mediaFileFacade = mediaFileFacade;
        SettingsCommand = new Command(OnSettingsClicked);
        SearchCommand = new Command(OnSearch);
        FilterCommand = new Command(OnFilterClicked);
        MediaSelectedCommand = new Command<MediaItem>(OnMediaSelected);
        MediaItems = new ObservableCollection<MediaItem>();
        GridSpan = 1; // Default span
        LoadMediaAsync().GetAwaiter().GetResult();
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

    public ICommand SettingsCommand { get; }
    public ICommand SearchCommand { get; }
    public ICommand FilterCommand { get; }
    public ICommand MediaSelectedCommand { get; }

    private async Task LoadMediaAsync()
    {
        try
        {
            //var mediaList = await _mediaFileFacade.GetAllAsync();
            //MediaItems.Clear();
            //foreach (var media in mediaList)
            //{
            //    MediaItems.Add(new MediaItem
            //    {
            //        Id = media.Id,
            //        Name = media.Name,
            //        Status = media.Status,
            //        Description = media.Description,
            //        Duration = media.Duration,
            //        Director = media.Director,
            //        ReleaseDate = media.ReleaseDate,
            //        Rating = media.Rating,
            //        Favourite = media.Favourite,
            //        MediaType = media.MediaType,
            //        GenreNames = media.GenreNames
            //    });
            //}
            var placeholders = new List<MediaItem>
            {
                new MediaItem
                {
                    Id = 1,
                    Name = "Inception",
                    Status = MediaStatus.Completed,
                    Description = "A mind-bending thriller by Christopher Nolan.",
                    Duration = 148,
                    Director = "Christopher Nolan",
                    ReleaseDate = 2010,
                    Rating = "PG-13",
                    URL = "https://example.com/inception.jpg",
                    Favourite = true,
                    MediaType = MediaType.Movie,
                    GenreNames = new List<string> { "Sci-Fi", "Thriller" }
                },
                new MediaItem
                {
                    Id = 2,
                    Name = "Breaking Bad",
                    Status = MediaStatus.Watching,
                    Description = "A high school chemistry teacher turned methamphetamine manufacturer.",
                    Duration = 49, // per episode
                    Director = "Vince Gilligan",
                    ReleaseDate = 2008,
                    Rating = "TV-MA",
                    URL = "https://example.com/breakingbad.jpg",
                    Favourite = false,
                    MediaType = MediaType.Series,
                    GenreNames = new List<string> { "Crime", "Drama" }
                }
            };
            MediaItems.Clear();
            foreach (var media in placeholders)
            {
                MediaItems.Add(media);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load media: {ex.Message}", "OK");
            System.Diagnostics.Debug.WriteLine($"Error loading media: {ex.Message}");
        }
    }

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
        if (Application.Current?.MainPage is not null && popup is not null)
        {
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var filters = (dynamic)result;

                var movieFilter = new MovieFilterQuery
                {
                    Genre = filters.Category == "All" ? null : filters.Category,
                    Favourite = filters.OnlyFavourites ? true : null,
                    ReleaseYear = (int)filters.MinReleaseYear,
                    SortBy = filters.SortOption switch
                    {
                        "Alphabetical" => "title",
                        "Favourites" => "favourite",
                        "Ranking" => "rating",
                        _ => "title"
                    },
                    SortOrder = filters.IsDescending ? "desc" : "asc"
                };
                await ApplyFilterAsync(movieFilter);
            }
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("MainPage alebo popup s� null � nem�em zobrazi� FilterPopup.");
        }
    }

    private async void OnMediaSelected(MediaItem mediaItem)
    {
        if (mediaItem == null) return;
        var viewModel = new MediaDetailViewModel(mediaItem);
        var detailPage = new MediaDetailPage(viewModel);
        await Application.Current!.MainPage!.Navigation.PushAsync(detailPage);
    }

    public async Task ApplyFilterAsync(MovieFilterQuery filter)
    {
        try
        {
            var allMovies = await _movieRepository.GetAllAsync(); 
            var query = allMovies.AsQueryable();

            var filtered = _movieService.ApplyFilter(query, filter).ToList();

            MediaItems.Clear();
            foreach (var movie in filtered)
            {
                MediaItems.Add(new MediaItem
                {
                    Title = movie.Name,
                    Length = movie.Duration,
                    Rating = movie.Rating,
                    ReleaseYear = movie.ReleaseDate,
                    Director = movie.Director,
                    ImageUrl = movie.URL,
                    IsFavourite = movie.Favourite,
                    Status = movie.Status.ToString(),
                    Genres = movie.Genres.Select(g => g.Name).ToList(),
                    IsPlaceholder = false
                });
            }

            if (MediaItems.Count == 0)
            {
                MediaItems.Add(new MediaItem
                {
                    Title = "No matching results found.",
                    IsPlaceholder = true
                });
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error applying filter: {ex.Message}");
            MediaItems.Clear();
            MediaItems.Add(new MediaItem
            {
                Title = "No matching results found.",
                IsPlaceholder = true
            });

        }
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
