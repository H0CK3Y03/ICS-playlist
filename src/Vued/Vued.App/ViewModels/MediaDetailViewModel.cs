using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Microsoft.EntityFrameworkCore;
using Vued.App.Views.MediaFile;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.App.ViewModels;

public class MediaDetailViewModel : BindableObject
{
    private readonly MediaFileFacade _mediaFileFacade;
    private readonly IServiceProvider _serviceProvider;
    private readonly MediaItem _mediaItem;
    private string _name;
    private string _rating;
    private string _releaseYear;
    private string _lengthOrEpisodes;
    private string _director;
    private string _genres;
    private string _description;
    private string _review;
    private string _url;
    private bool _favourite;
    private MediaStatus _status;
    private MediaType _mediaType;

    public MediaDetailViewModel(MediaItem mediaItem , IServiceProvider serviceProvider)
    {
        _mediaItem = mediaItem;
        GoBackCommand = new Command(OnGoBack);
        EditCommand = new Command(OnEdit);
        System.Diagnostics.Debug.WriteLine("[AHHH]MediaDetailViewModel");
        LoadMediaDetailsAsync().GetAwaiter().GetResult();
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
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

    public string URL
    {
        get => _url;
        set
        {
            _url = value;
            OnPropertyChanged();
        }
    }

    public bool Favourite
    {
        get => _favourite;
        set
        {
            _favourite = value;
            OnPropertyChanged();
        }
    }

    public MediaStatus Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged();
        }
    }

    public MediaType MediaType
    {
        get => _mediaType;
        set
        {
            _mediaType = value;
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
            var viewModel = new MediaEditViewModel(_mediaItem, _serviceProvider);
            var popup = new MediaEditPopup(viewModel);
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            if (result != null)
            {
                var updatedMedia = (dynamic)result;
                // Update ViewModel properties with edited values
                Name = updatedMedia.Name;
                Rating = updatedMedia.Rating;
                ReleaseYear = updatedMedia.ReleaseYear;
                LengthOrEpisodes = updatedMedia.LengthOrEpisodes;
                Director = updatedMedia.Director;
                Genres = updatedMedia.Genres;
                Description = updatedMedia.Description;
                Review = updatedMedia.Review;
                // TODO: Save to database when DAL is ready
                System.Diagnostics.Debug.WriteLine($"Updated media: {Name}, {Rating}, {ReleaseYear}");
            }
        }
    }

    private async Task LoadMediaDetailsAsync()
    {
        try
        {
            if (_mediaItem == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Media not found", "OK");
                await Shell.Current.Navigation.PopAsync();
                return;
            }

            Name = _mediaItem.Name;
            Rating = _mediaItem.Rating;
            ReleaseYear = _mediaItem.ReleaseDate.ToString();
            LengthOrEpisodes = _mediaItem.MediaType == MediaType.Movie
                ? $"{_mediaItem.Duration} min"
                : $"{_mediaItem.Duration} episodes";
            Director = _mediaItem.Director;
            Genres = _mediaItem.GenreNames != null
                ? string.Join(", ", _mediaItem.GenreNames)
                : string.Empty;
            Description = _mediaItem.Description ?? "No description available";
            Review = "Good.";
            URL = _mediaItem.URL ?? string.Empty;
            Favourite = _mediaItem.Favourite;
            Status = _mediaItem.Status;
            MediaType = _mediaItem.MediaType;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load media details: {ex.Message}", "OK");
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
