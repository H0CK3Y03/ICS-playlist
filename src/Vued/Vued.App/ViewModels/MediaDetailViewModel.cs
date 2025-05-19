using System.Windows.Input;

namespace Vued.App.ViewModels;

public class MediaDetailViewModel : BindableObject
{
    private readonly MediaItem _mediaItem;

    public MediaDetailViewModel(MediaItem mediaItem)
    {
        _mediaItem = mediaItem;
        GoBackCommand = new Command(OnGoBack);
    }

    public string Title => _mediaItem.Title;

    public ICommand GoBackCommand { get; }

    private async void OnGoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }
}