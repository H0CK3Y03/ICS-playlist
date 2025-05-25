using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;
using Vued.App.Views.Add;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.DAL.Repositories;
using Vued.BL;
using Vued.BL.Models;
using Vued.BL.Queries;


namespace Vued.App.Views;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        try
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
            SizeChanged += OnSizeChanged;
            _viewModel.ShowPopupAsyncDelegate = async popup => await this.ShowPopupAsync(popup);
            _viewModel.ShowAlertAsyncDelegate = async (title, message, cancel) =>
                await DisplayAlert(title, message, cancel);
        }
        catch (Exception ex)
        {
            // Log to Output window
            System.Diagnostics.Debug.WriteLine($"MainPage constructor failed: {ex.Message}\nStackTrace: {ex.StackTrace}");
            // Display alert to user
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
        var popup = new AddPopup();
        await this.ShowPopupAsync(popup);
    }

}
