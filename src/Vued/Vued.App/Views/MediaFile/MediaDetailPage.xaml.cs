using Vued.App.ViewModels;

namespace Vued.App.Views.MediaFile;

public partial class MediaDetailPage : ContentPage
{
    public MediaDetailPage(MediaDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}