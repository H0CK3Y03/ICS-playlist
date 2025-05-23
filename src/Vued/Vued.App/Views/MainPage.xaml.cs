using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;
using Vued.App.Views.Add;

namespace Vued.App.Views;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
        SizeChanged += OnSizeChanged;
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
}