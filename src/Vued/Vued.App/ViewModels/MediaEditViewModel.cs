using System.Collections.ObjectModel;
using System.Windows.Input;
using Vued.BL.Facades;
using Vued.DAL.Entities;
using Vued.App.Utilities;

namespace Vued.App.ViewModels;

public class MediaEditViewModel : BindableObject
{
    private readonly MediaItem _mediaItem;
    private readonly MediaFileFacade _mediaFileFacade;
    private readonly GenreFacade _genreFacade;
    private ObservableCollection<string> _ratings;
    private ObservableCollection<GenreCheckbox> _availableGenres;

    private string _name;
    private string _url;
    private string _imageUrl;
    private bool _favourite;
    private MediaStatus _status;
    private MediaType _mediaType;
    private string _rating;
    private string _releaseYear;
    private string _lengthOrEpisodes;
    private string _director;
    private string _description;
    private string _review;

    public MediaEditViewModel(MediaItem mediaItem, IServiceProvider serviceProvider)
    {
        _mediaFileFacade = serviceProvider.GetRequiredService<MediaFileFacade>();
        _genreFacade = serviceProvider.GetRequiredService<GenreFacade>();
        _mediaItem = mediaItem;

        Ratings = new ObservableCollection<string>
        {
            "0/10", "1/10", "2/10", "3/10", "4/10", "5/10",
            "6/10", "7/10", "8/10", "9/10", "10/10"
        };

        AvailableGenres = new ObservableCollection<GenreCheckbox>();
        Name = _mediaItem.Name;
        Rating = _mediaItem.Rating;
        ReleaseYear = _mediaItem.ReleaseDate.ToString();
        LengthOrEpisodes = _mediaItem.MediaType == MediaType.Movie
            ? $"{_mediaItem.Duration} min"
            : $"{_mediaItem.Duration} episodes";
        Director = _mediaItem.Director;
        Description = _mediaItem.Description ?? "No description available";
        Review = _mediaItem.Review;
        URL = _mediaItem.URL ?? string.Empty;
        ImageURL = _mediaItem.ImageURL ?? string.Empty;
        Favourite = _mediaItem.Favourite;
        Status = _mediaItem.Status;
        MediaType = _mediaItem.MediaType;

        EditCommand = new Command(async () => await OnEdit());
        DeleteCommand = new Command(async () => await OnDelete());

        InitializeGenresAsync().GetAwaiter().GetResult();
    }

    private async Task InitializeGenresAsync()
    {
        try
        {
            var allGenres = await _genreFacade.GetAllAsync();
            var mediaGenreIds = await _mediaFileFacade.GetGenreIdsForMediaAsync(_mediaItem.Id);

            AvailableGenres = new ObservableCollection<GenreCheckbox>(
                allGenres.Select(g => new GenreCheckbox
                {
                    Id = g.Id,
                    Name = g.Name,
                    IsSelected = mediaGenreIds.Contains(g.Id)
                }));
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading genres", ex);
            AlertDisplay.ShowAlertAsync("Error", $"Failed to load genres: {ex.Message}", "OK").GetAwaiter().GetResult();
        }
    }

    public ICommand EditCommand { get; }

    public async Task OnEdit()
    {
        try
        {
            var currentMediaModel = await _mediaFileFacade.GetByIdAsync(_mediaItem.Id);
            if (currentMediaModel == null)
            {
                throw new InvalidOperationException("Media item not found for update.");
            }

            currentMediaModel.Name = Name;
            currentMediaModel.Status = Status;
            currentMediaModel.Description = Description;
            currentMediaModel.Duration = int.TryParse(LengthOrEpisodes.Split(' ')[0], out var duration) ? duration : 0;
            currentMediaModel.Director = Director;
            currentMediaModel.ReleaseDate = int.TryParse(ReleaseYear, out var releaseYear) ? releaseYear : 0;
            currentMediaModel.Rating = Rating;
            currentMediaModel.URL = URL;
            currentMediaModel.ImageURL = ImageURL;
            currentMediaModel.Favourite = Favourite;
            currentMediaModel.MediaType = MediaType;
            currentMediaModel.Review = Review;

            await _mediaFileFacade.SaveAsync(currentMediaModel);

            var selectedGenreIds = AvailableGenres.Where(g => g.IsSelected).Select(g => g.Id).ToList();
            var currentGenreIds = await _mediaFileFacade.GetGenreIdsForMediaAsync(_mediaItem.Id);

            foreach (var genreId in selectedGenreIds.Except(currentGenreIds))
            {
                try
                {
                    await _mediaFileFacade.AddGenreToMediaAsync(_mediaItem.Id, genreId);
                    Logger.Debug(GetType(), $"Linked genre ID {genreId} to media ID {_mediaItem.Id}");
                }
                catch (Exception ex)
                {
                    Logger.Error(GetType(), $"Error linking genre ID {genreId} to media ID {_mediaItem.Id}", ex);
                }
            }

            foreach (var genreId in currentGenreIds.Except(selectedGenreIds))
            {
                try
                {
                    await _mediaFileFacade.RemoveGenreFromMediaAsync(_mediaItem.Id, genreId);
                    Logger.Debug(GetType(), $"Unlinked genre ID {genreId} from media ID {_mediaItem.Id}");
                }
                catch (Exception ex)
                {
                    Logger.Error(GetType(), $"Error unlinking genre ID {genreId} from media ID {_mediaItem.Id}", ex);
                }
            }

            await AlertDisplay.ShowAlertAsync("Success", "Media updated successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error updating media", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to update media: {ex.Message}", "OK");
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

    public ObservableCollection<GenreCheckbox> AvailableGenres
    {
        get => _availableGenres;
        set
        {
            _availableGenres = value;
            OnPropertyChanged();
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

    public string ImageURL
    {
        get => _imageUrl;
        set
        {
            _imageUrl = value;
            OnPropertyChanged();
        }
    }
}