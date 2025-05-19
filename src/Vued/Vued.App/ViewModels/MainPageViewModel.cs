using System.ComponentModel;
using System.Windows.Input;
using Vued.App.Views;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Maui.Views;

namespace Vued.App.ViewModels;

public class MainPageViewModel : BindableObject
{
    private readonly IServiceProvider _serviceProvider;
    private string _searchQuery;

    public MainPageViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        SearchCommand = new Command(OnSearch);
        FilterCommand = new Command(OnFilterClicked);
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
}