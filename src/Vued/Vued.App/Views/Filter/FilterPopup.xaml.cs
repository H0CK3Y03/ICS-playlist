using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.ViewModels;
using Vued.BL.Models;

namespace Vued.App.Views.Filter;

public partial class FilterPopup : Popup
{
    public FilterPopup(FilterPopupViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void OnApplyClicked(object sender, EventArgs e)
    {
        try
        {
            var viewModel = (FilterPopupViewModel)BindingContext;
            var filters = new MovieApplyFilterModel
            {
                Category = viewModel.SelectedCategory ?? "All",
                SortOption = viewModel.SelectedSortOption ?? "Alphabetical",
                MinReleaseYear = viewModel.MinReleaseYear,
                OnlyFavourites = viewModel.OnlyFavourites,
                IsDescending = viewModel.IsDescending
            };
            Close(filters);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Filter apply error: {ex.Message}");
            Close();
        }
    }
}
