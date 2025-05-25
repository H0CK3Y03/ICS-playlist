using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;

namespace Vued.App.Views.MediaFile;

public partial class MediaEditPopup : Popup
{
    public MediaEditPopup(MediaEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        // TODO
        Close();
    }

    private void OnApplyClicked(object sender, EventArgs e)
    {
        var viewModel = (MediaEditViewModel)BindingContext;
        var updatedMedia = new
        {
            Name = viewModel.Name,
            Rating = viewModel.SelectedRating,
            ReleaseYear = viewModel.ReleaseYear,
            LengthOrEpisodes = viewModel.LengthOrEpisodes,
            Director = viewModel.Director,
            Genres = viewModel.Genres,
            Description = viewModel.Description,
            Review = viewModel.Review
        };
        Close(updatedMedia);
    }
}
