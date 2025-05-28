using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;
using Vued.App.Views.Add;
using Vued.App.Utilities;

namespace Vued.App.Views;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;
    private readonly IServiceProvider _serviceProvider;

    public MainPage(MainPageViewModel viewModel, IServiceProvider serviceProvider)
    {
        try
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
            SizeChanged += OnSizeChanged;
            _serviceProvider = serviceProvider;
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Main page constructor failed", ex);
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        _viewModel.UpdateGridSpan(Width);
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        var popup = new AddPopup(_serviceProvider, _viewModel);
        await this.ShowPopupAsync(popup);
    }
}
