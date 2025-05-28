using CommunityToolkit.Maui.Views;
using Vued.App.Utilities;
using Vued.App.ViewModels;

namespace Vued.App.Views.Watchlist;

public partial class WatchlistDetail : ContentPage
{
    private readonly WatchlistDetailViewModel _viewModel;

    public WatchlistDetail(WatchlistDetailViewModel viewModel, IServiceProvider serviceProvider)
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
            Logger.Error(GetType(), "WatchlistDetail constructor failed", ex);
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
}