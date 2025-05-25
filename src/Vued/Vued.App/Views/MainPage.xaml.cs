using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;
using Vued.App.Views.Add;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.DAL.Repositories;
using Vued.BL;
using Vued.BL.Queries;


namespace Vued.App.Views;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        try
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
            SizeChanged += OnSizeChanged;
        }
        catch (Exception ex)
        {
            // Log to Output window
            System.Diagnostics.Debug.WriteLine($"MainPage constructor failed: {ex.Message}\nStackTrace: {ex.StackTrace}");
            // Display alert to user
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Error", $"Failed to initialize MainPage: {ex.Message}", "OK");
            });
            // Rethrow in Debug to pause in debugger
#if DEBUG
            throw;
#endif
        }

    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        _viewModel.UpdateGridSpan(Width);
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        var popup = new AddPopup();
        await this.ShowPopupAsync(popup);
    }


    private async void OnFilterButtonClicked(object sender, EventArgs e)
    {
        var filterPopup = new FilterPopup(new FilterPopupViewModel());
        var result = await this.ShowPopupAsync(filterPopup);

        if (result is not null)
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

            await _viewModel.ApplyFilterAsync(movieFilter);
        }
    }

}
