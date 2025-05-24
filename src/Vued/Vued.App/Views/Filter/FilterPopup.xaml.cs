using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.ViewModels;

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
        var viewModel = (FilterPopupViewModel)BindingContext;
        var filters = new
        {
            Category = viewModel.SelectedCategory,
            SortOption = viewModel.SelectedSortOption,
            MinReleaseYear = viewModel.MinReleaseYear,
            OnlyFavourites = viewModel.OnlyFavourites,
            IsDescending = viewModel.IsDescending
        };
        Close(filters);
    }
}
