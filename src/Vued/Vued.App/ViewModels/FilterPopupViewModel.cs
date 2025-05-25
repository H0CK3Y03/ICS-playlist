using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Vued.App.ViewModels;

public class FilterPopupViewModel : BindableObject
{
    private ObservableCollection<string> _categories;
    private string _selectedCategory;
    private ObservableCollection<string> _sortOptions;
    private string _selectedSortOption;
    private double _minReleaseYear;
    private bool _onlyFavourites;
    private bool _isDescending;

    public FilterPopupViewModel()
    {
        Categories = new ObservableCollection<string>();
        SortOptions = new ObservableCollection<string>();
        LoadFilterOptions();
        ApplyCommand = new Command(OnApply);
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
        // Hardcoded categories (to be replaced with DAL later)
        var hardcodedCategories = new List<string>
        {
            "All",
            "Drama",
            "Fantasy",
            "Sci-fi",
            "Comedy",
            "Romance",
            "Horror"
        };
        Categories.Clear();
        foreach (var category in hardcodedCategories)
        {
            Categories.Add(category);
        }
        if (Categories.Count > 0)
        {
            SelectedCategory = Categories[0]; // Default selection
        }

        // Hardcoded sort options
        var hardcodedSortOptions = new List<string>
        {
            "Alphabetical",
            "Favourites",
            "Ranking"
        };
        SortOptions.Clear();
        foreach (var sortOption in hardcodedSortOptions)
        {
            SortOptions.Add(sortOption);
        }
        if (SortOptions.Count > 0)
        {
            SelectedSortOption = SortOptions[0]; // Default selection
        }

        // Initialize other filter defaults
        MinReleaseYear = 2000;
        OnlyFavourites = false;
        IsDescending = false;
    }

    private void OnApply()
    {
        // Handled in FilterPopup.xaml.cs
    }
}