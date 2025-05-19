using Vued.App.ViewModels;

namespace Vued.App.Views;

public partial class MediaDetailPage : ContentPage
{
    public MediaDetailPage(MediaDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}