using System.Collections.ObjectModel;
using System.Windows.Input;
using Vued.BL.Facades;
using Vued.App.Utilities;

namespace Vued.App.ViewModels;

public class FilterPopupViewModel : BindableObject
{
    private readonly GenreFacade _genreFacade;
    private ObservableCollection<string> _categories;
    private ObservableCollection<string> _sortOptions;
    private string _selectedCategory;
    private string _selectedSortOption;
    private double _minReleaseYear;
    private bool _onlyFavourites;
    private bool _isDescending;

    public FilterPopupViewModel(IServiceProvider serviceProvider)
    {
        _genreFacade = serviceProvider.GetRequiredService<GenreFacade>();
        Categories = new ObservableCollection<string>();
        SortOptions = new ObservableCollection<string>();
        ApplyCommand = new Command(OnApply);
        LoadFilterOptions();
    }

    public ObservableCollection<string> Categories
    {
        get => _categories;
        set
        {
            _categories = value;
            OnPropertyChanged();
        }
    }

    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            _selectedCategory = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> SortOptions
    {
        get => _sortOptions;
        set
        {
            _sortOptions = value;
            OnPropertyChanged();
        }
    }

    public string SelectedSortOption
    {
        get => _selectedSortOption;
        set
        {
            _selectedSortOption = value;
            OnPropertyChanged();
        }
    }

    public double MinReleaseYear
    {
        get => _minReleaseYear;
        set
        {
            _minReleaseYear = value;
            OnPropertyChanged();
        }
    }

    public bool OnlyFavourites
    {
        get => _onlyFavourites;
        set
        {
            _onlyFavourites = value;
            OnPropertyChanged();
        }
    }

    public bool IsDescending
    {
        get => _isDescending;
        set
        {
            _isDescending = value;
            OnPropertyChanged();
        }
    }

    public ICommand ApplyCommand { get; }

    private void LoadFilterOptions()
    {
        try
        {
            var genres = _genreFacade.GetAllAsync().GetAwaiter().GetResult();
            Categories.Clear();
            Categories.Add("All");
            foreach (var genre in genres.OrderBy(g => g.Name))
            {
                Categories.Add(genre.Name);
            }
            SelectedCategory = Categories.Any() ? Categories[0] : null;
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading genres", ex);
            AlertDisplay.ShowAlertAsync("Error", $"Failed to load genres: {ex.Message}", "OK").GetAwaiter().GetResult();
        }

        var sortOptions = new List<string>
        {
            "Alphabetical",
            "Favourites",
            "Ranking"
        };
        SortOptions.Clear();
        foreach (var sortOption in sortOptions)
        {
            SortOptions.Add(sortOption);
        }
        SelectedSortOption = SortOptions.Any() ? SortOptions[0] : null;

        MinReleaseYear = 1000;
        OnlyFavourites = false;
        IsDescending = false;
    }

    private void OnApply() { /* Handled inside Views.Filter */ }
}