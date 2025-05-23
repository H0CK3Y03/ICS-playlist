using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Vued.App.Views.MediaFile;

namespace Vued.App.ViewModels;

public class MediaDetailViewModel : BindableObject
{
    private readonly MediaItem _mediaItem;
    private string _title;
    private string _rating;
    private string _releaseYear;
    private string _lengthOrEpisodes;
    private string _director;
    private string _genres;
    private string _description;
    private string _review;

    public MediaDetailViewModel(MediaItem mediaItem)
    {
        _mediaItem = mediaItem;
        Title = mediaItem.Title;
        Rating = "10/10"; // Hardcoded for now
        ReleaseYear = "1999";
        LengthOrEpisodes = "1h 20min / 22 episodes";
        Director = "Director Name";
        Genres = "Fantasy, Horror, Sci-fi";
        Description = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";
        Review = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";
        GoBackCommand = new Command(OnGoBack);
        EditCommand = new Command(OnEdit);
    }

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public string Rating
    {
        get => _rating;
        set
        {
            _rating = value;
            OnPropertyChanged();
        }
    }

    public string ReleaseYear
    {
        get => _releaseYear;
        set
        {
            _releaseYear = value;
            OnPropertyChanged();
        }
    }

    public string LengthOrEpisodes
    {
        get => _lengthOrEpisodes;
        set
        {
            _lengthOrEpisodes = value;
            OnPropertyChanged();
        }
    }

    public string Director
    {
        get => _director;
        set
        {
            _director = value;
            OnPropertyChanged();
        }
    }

    public string Genres
    {
        get => _genres;
        set
        {
            _genres = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged();
        }
    }

    public string Review
    {
        get => _review;
        set
        {
            _review = value;
            OnPropertyChanged();
        }
    }

    public ICommand GoBackCommand { get; }
    public ICommand EditCommand { get; }

    private async void OnGoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async void OnEdit()
    {
        if (Application.Current?.MainPage != null)
        {
            var viewModel = new MediaEditViewModel(_mediaItem);
            var popup = new MediaEditPopup(viewModel);
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var updatedMedia = (dynamic)result;
                // Update ViewModel properties with edited values
                Title = updatedMedia.Title;
                Rating = updatedMedia.Rating;
                ReleaseYear = updatedMedia.ReleaseYear;
                LengthOrEpisodes = updatedMedia.LengthOrEpisodes;
                Director = updatedMedia.Director;
                Genres = updatedMedia.Genres;
                Description = updatedMedia.Description;
                Review = updatedMedia.Review;
                // TODO: Save to database when DAL is ready
                System.Diagnostics.Debug.WriteLine($"Updated media: {Title}, {Rating}, {ReleaseYear}");
            }
        }
    }
}