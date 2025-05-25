using CommunityToolkit.Maui.Views;
using Vued.App.ViewModels;
using Vued.App.Views.Add;

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
        }
        catch (Exception ex)
        {
            // Log to Output window
            System.Diagnostics.Debug.WriteLine($"MainPage constructor failed: {ex.Message}\nStackTrace: {ex.StackTrace}");
            // Display alert to user
        }
    }
                await DisplayAlert("Error", $"Failed to initialize MainPage: {ex.Message}", "OK");
            });
            // Rethrow in Debug to pause in debugger
#if DEBUG
            throw;
#endif
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
