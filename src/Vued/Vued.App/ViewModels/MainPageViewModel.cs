using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Vued.App.Views;

namespace Vued.App.ViewModels;

public class MainPageViewModel : BindableObject
{
    private string _searchQuery;

    public MainPageViewModel()
    {
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
            var popup = new FilterPopup();
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            if (result != null)
            {
                // Handle filter results
                var filters = (dynamic)result;
                System.Diagnostics.Debug.WriteLine($"Filters applied: Category1={filters.Category1}, Category2={filters.Category2}");
                // Example: Update search with filters
                // await _searchService.SearchAsync(SearchQuery, filters);
            }
        }
    }
}