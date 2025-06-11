namespace Vued.App.Views.MediaFile;

public partial class MediaPlayer : ContentPage
{
    public MediaPlayer(string url)
    {
        InitializeComponent();
        BindingContext = url;
    }
}