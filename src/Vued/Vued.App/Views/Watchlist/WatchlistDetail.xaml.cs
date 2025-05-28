using Vued.App.Utilities;
using Vued.App.ViewModels;

namespace Vued.App.Views.Watchlist;

public partial class WatchlistDetail : ContentPage
{
    private readonly WatchlistDetailViewModel _viewModel;
    private readonly IServiceProvider _serviceProvider;
    private double _detailsGridHeight;
    private double _boxViewHeight;
    private double _boxViewWidth;
    private bool _isHeightMeasured;

    public WatchlistDetail(WatchlistDetailViewModel viewModel, IServiceProvider serviceProvider)
    {
        try
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
            _serviceProvider = serviceProvider;
            SizeChanged += OnSizeChanged;
            Loaded += OnLoaded;
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

    private void OnLoaded(object sender, EventArgs e)
    {
        if (!_isHeightMeasured)
        {
            _detailsGridHeight = DetailsGrid.Height > 0 ? DetailsGrid.Height : 200;
            _boxViewHeight = PlaceholderBoxView.Height > 0 ? PlaceholderBoxView.Height : 200;
            _boxViewWidth = PlaceholderBoxView.Width > 0 ? PlaceholderBoxView.Width : 200;
            _isHeightMeasured = true;
        }
    }

    private void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
    {
        if (!_isHeightMeasured) return;

        double maxReduction = _detailsGridHeight / 2.8;
        double reduction = Math.Clamp(e.ScrollY, 0, maxReduction);
        double newGridHeight = _detailsGridHeight - reduction;
        DetailsGrid.HeightRequest = Math.Max(newGridHeight, 0);

        double newBoxHeight = Math.Min(_boxViewHeight, newGridHeight - DetailsGrid.Padding.VerticalThickness);
        newBoxHeight = Math.Max(newBoxHeight, 0);
        PlaceholderBoxView.HeightRequest = newBoxHeight;
        PlaceholderBoxView.WidthRequest = newBoxHeight;
    }
}