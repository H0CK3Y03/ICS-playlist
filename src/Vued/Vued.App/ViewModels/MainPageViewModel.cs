using System.ComponentModel;
using System.Windows.Input;

namespace Vued.App.ViewModels;

public class MainPageViewModel : BindableObject
{
    private string _searchQuery;

    public MainPageViewModel()
    {
        SettingsCommand = new Command(OnSettingsClicked);
        SearchCommand = new Command(OnSearch);
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

    public ICommand SettingsCommand { get; }
    public ICommand SearchCommand { get; }

    private async void OnSettingsClicked()
    {
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlert("Settings", "Settings clicked!", "OK");
        }
    }

    private void OnSearch()
    {
        // Placeholder: Implement search logic (e.g., call Vued.BL service)
        if (!string.IsNullOrEmpty(SearchQuery))
        {
            // Example: Call a BL service
            // var results = await _searchService.SearchAsync(SearchQuery);
            System.Diagnostics.Debug.WriteLine($"Search query: {SearchQuery}");
        }
    }
}