using System.Collections.ObjectModel;
using System.Windows.Input;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.App.Utilities;

namespace Vued.App.ViewModels;

public class MediaEditViewModel : BindableObject
{
    private readonly MediaItem _mediaItem;
    private ObservableCollection<string> _ratings;
    private readonly MediaFileFacade _mediaFileFacade;

    private string _name;
    private string _url;
    private string _imageUrl;
    private bool _favourite;
    private MediaStatus _status;
    private MediaType _mediaType;
    private string _rating;
    private string _selectedRating;
    private string _releaseYear;
    private string _lengthOrEpisodes;
    private string _director;
    private string _genres;
    private string _description;
    private string _review;

    public MediaEditViewModel(MediaItem mediaItem, IServiceProvider serviceProvider)
    {
        _mediaFileFacade = serviceProvider.GetRequiredService<MediaFileFacade>();
        _mediaItem = mediaItem;

        Ratings = new ObservableCollection<string>
        {
            "1/10", "2/10", "3/10", "4/10", "5/10",
            "6/10", "7/10", "8/10", "9/10", "10/10"
        };

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
        Review = "TODO";
        URL = _mediaItem.URL ?? string.Empty;
        ImageUrl = _mediaItem.URL ?? string.Empty; // change later
        Favourite = _mediaItem.Favourite;
        Status = _mediaItem.Status;
        MediaType = _mediaItem.MediaType;

        EditCommand = new Command(async () => await OnEdit());
        DeleteCommand = new Command(async () => await OnDelete());
    }

    public ICommand EditCommand { get; }

    public async Task OnEdit()
    {
        try
        {
            var updatedMediaItem = new MediaItem
            {
                Id = _mediaItem.Id,
                Name = Name,
                Rating = Rating,
                ReleaseDate = int.Parse(ReleaseYear),
                Duration = int.Parse(LengthOrEpisodes.Split(' ')[0]),
                Director = Director,
                GenreNames = Genres.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList(),
                Description = Description,
                URL = ImageUrl,
                Favourite = Favourite,
                Status = Status,
                MediaType = MediaType
            };

            var currentMediaModel = await _mediaFileFacade.GetByIdAsync(_mediaItem.Id);
            if (currentMediaModel == null)
            {
                Logger.Debug(GetType(), "Media item not found for update");
                throw new InvalidOperationException("Media item not found for update.");
            }
            currentMediaModel.Name = updatedMediaItem.Name;
            currentMediaModel.Status = updatedMediaItem.Status;
            currentMediaModel.Description = updatedMediaItem.Description;
            currentMediaModel.Duration = updatedMediaItem.Duration;
            currentMediaModel.Director = updatedMediaItem.Director;
            currentMediaModel.ReleaseDate = updatedMediaItem.ReleaseDate;
            currentMediaModel.Rating = updatedMediaItem.Rating;
            currentMediaModel.URL = updatedMediaItem.URL;
            currentMediaModel.Favourite = updatedMediaItem.Favourite;
            currentMediaModel.MediaType = updatedMediaItem.MediaType;
            currentMediaModel.GenreNames = updatedMediaItem.GenreNames;

            await _mediaFileFacade.SaveAsync(currentMediaModel);

            await AlertDisplay.ShowAlertAsync("Success", "Media updated successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error updating media", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to udated media: {ex.Message}", "OK");
        }
    }

    public ICommand DeleteCommand { get; }

    private async Task OnDelete()
    {
        try
        {
            await _mediaFileFacade.DeleteAsync(_mediaItem.Id);

            await AlertDisplay.ShowAlertAsync("Success", "Media item deleted successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error deleting media", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to delete media: {ex.Message}", "OK");
        }
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

    public ObservableCollection<string> Ratings
    {
        get => _ratings;
        set
        {
            _ratings = value;
            OnPropertyChanged();
        }
    }

    public string SelectedRating
    {
        get => _selectedRating;
        set
        {
            _selectedRating = value;
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

    public string Rating
    {
        get => _rating;
        set
        {
            _rating = value;
            OnPropertyChanged();
        }
    }

    public string ImageUrl
    {
        get => _imageUrl;
        set
        {
            _imageUrl = value;
            OnPropertyChanged();
        }
    }
}
