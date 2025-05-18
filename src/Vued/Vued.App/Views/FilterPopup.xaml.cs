using CommunityToolkit.Maui.Views;

namespace Vued.App.Views;

public partial class FilterPopup : Popup
{
    public FilterPopup()
    {
        InitializeComponent();
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close(); // Just closes the popup without passing data
    }

    private void OnApplyClicked(object sender, EventArgs e)
    {
        // Collect filter selections from UI elements
        var filters = new
        {
            SelectedCategory = CategoryPicker.SelectedItem?.ToString(),
            SortBy = SortPicker.SelectedItem?.ToString(),
            MinimumYear = (int)ReleaseYearSlider.Value,
            OnlyFavourites = FavouritesCheckBox.IsChecked,
            Descending = DescendingCheckbox.IsChecked
        };

        Close(filters); // Pass collected filter data back to the caller
    }
}