using Vued.App.ViewModels;

namespace Vued.App.Views.MediaFile;

public partial class MediaDetailPage : ContentPage
{
    public MediaDetailPage(MediaDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
        if (BindingContext is MediaDetailViewModel viewModel && !string.IsNullOrEmpty(viewModel.URL))
        {
            string videoUrl = viewModel.URL;
            if (videoUrl.Contains("youtube.com/watch?v="))
            {
                var videoId = videoUrl.Split("v=")[1].Split('&')[0];
                videoUrl = $"https://www.youtube.com/embed/{videoId}?autoplay=1";
            }
            await Navigation.PushAsync(new MediaPlayer(videoUrl));
        }
        else
        {
            await DisplayAlert("Error", "No webpage URL available.", "OK");
        }
    }
}