using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.Views;

namespace Vued.App.ViewModels;

public class MainPageViewModel : BindableObject
{
    private readonly IServiceProvider _serviceProvider;
    private string _searchQuery;
    private ObservableCollection<MediaItem> _mediaItems;
    private int _gridSpan;

    public MainPageViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        SettingsCommand = new Command(OnSettingsClicked);
        SearchCommand = new Command(OnSearch);
        FilterCommand = new Command(OnFilterClicked);
        MediaSelectedCommand = new Command<MediaItem>(OnMediaSelected);
        MediaItems = new ObservableCollection<MediaItem>();
        GridSpan = 1; // Default span
        LoadPlaceholderMedia();
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

    private void LoadPlaceholderMedia()
    {
        // Hardcoded placeholder media items (to be replaced with DAL later)
        var placeholders = new[]
        {
            new MediaItem { Title = "Media 1", IsPlaceholder = true },
            new MediaItem { Title = "Media 2", IsPlaceholder = true },
            new MediaItem { Title = "Media 3", IsPlaceholder = true },
            new MediaItem { Title = "Media 4", IsPlaceholder = true },
            new MediaItem { Title = "Media 5", IsPlaceholder = true },
            new MediaItem { Title = "Media 6", IsPlaceholder = true },
            new MediaItem { Title = "Media 7", IsPlaceholder = true },
            new MediaItem { Title = "Media 8", IsPlaceholder = true },
            new MediaItem { Title = "Media 9", IsPlaceholder = true },
            new MediaItem { Title = "Media 10", IsPlaceholder = true },
            new MediaItem { Title = "Media 11", IsPlaceholder = true },
            new MediaItem { Title = "Media 12", IsPlaceholder = true }
        };
        foreach (var item in placeholders)
        {
            MediaItems.Add(item);
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
        var viewModel = new MediaDetailViewModel(mediaItem);
        var detailPage = new MediaDetailPage(viewModel);
        await Application.Current.MainPage.Navigation.PushAsync(detailPage);
    }
}

public class MediaItem
{
    public string Title { get; set; }
    public bool IsPlaceholder { get; set; }
    // Add more properties as needed (e.g., ImageUrl, Id) when integrating with DAL
}