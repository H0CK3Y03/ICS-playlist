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
        //_mediaFileFacade = mediaFileFacade;
        GoBackCommand = new Command(OnGoBack);
        EditCommand = new Command(OnEdit);
        System.Diagnostics.Debug.WriteLine("[AHHH]MediaDetailViewModel");
        //LoadMediaDetailsAsync().GetAwaiter().GetResult();
        Name = mediaItem.Name;
        Rating = mediaItem.Rating;
        ReleaseYear = mediaItem.ReleaseDate.ToString();
        LengthOrEpisodes = mediaItem.MediaType == MediaType.Movie
            ? $"{mediaItem.Duration} min"
            : $"{mediaItem.Duration} episodes";
        _serviceProvider = serviceProvider;

        //Rating = "10/10"; // Hardcoded for now
        //ReleaseYear = "1999";
        //LengthOrEpisodes = "1h 20min / 22 episodes";
        //Director = "Director Name";
        //Genres = "Fantasy, Horror, Sci-fi";
        //Description = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";
        //Review = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";
        //GoBackCommand = new Command(OnGoBack);
        //EditCommand = new Command(OnEdit);
    }

    //public MediaDetailViewModel(MediaItem mediaItem)
    //{
    //    _mediaItem = mediaItem;
    //}

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
            var mediaDetail = await _mediaFileFacade.GetByIdAsync(_mediaItem.Id);
            if (mediaDetail == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Media not found", "OK");
                await Shell.Current.Navigation.PopAsync();
                return;
            }

            Name = mediaDetail.Name;
            Rating = mediaDetail.Rating;
            ReleaseYear = mediaDetail.ReleaseDate.ToString();
            LengthOrEpisodes = mediaDetail.MediaType == MediaType.Movie
                ? $"{mediaDetail.Duration} min"
                : $"{mediaDetail.Duration} episodes";
            Director = mediaDetail.Director;
            Genres = mediaDetail.GenreNames != null
                ? string.Join(", ", mediaDetail.GenreNames)
                : string.Empty;
            Description = mediaDetail.Description ?? "No description available";
            Review = "";
            URL = mediaDetail.URL ?? string.Empty;
            Favourite = mediaDetail.Favourite;
            Status = mediaDetail.Status;
            MediaType = mediaDetail.MediaType;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load media details: {ex.Message}", "OK");
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
