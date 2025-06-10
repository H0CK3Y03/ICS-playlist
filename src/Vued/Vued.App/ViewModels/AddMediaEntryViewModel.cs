using System.Windows.Input;
using Vued.App.Utilities;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;
using System.Collections.ObjectModel;

namespace Vued.App.ViewModels;

public class GenreCheckbox : BindableObject
{
    private bool _isSelected;

    public int Id { get; set; }
    public string Name { get; set; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            OnPropertyChanged();
        }
    }
}

public class AddMediaEntryViewModel
{
    private readonly GenreFacade _genreFacade;
    private readonly MediaFileFacade _mediaFileFacade;
    private readonly Action _onSaveComplete;

    public string Name { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string LengthOrEpisodes { get; set; } = string.Empty;
    public string Rating { get; set; } = "0/10";
    public string ImageUrl { get; set; } = string.Empty;
    public string ReleaseYear { get; set; } = string.Empty;
    public string MediaUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Review { get; set; } = string.Empty;
    public bool Favourite { get; set; } = false;
    public string SelectedMediaType { get; set; } = "Movie";

    public List<string> Ratings { get; } = new()
    {
        "0/10", "1/10", "2/10", "3/10", "4/10", "5/10",
        "6/10", "7/10", "8/10", "9/10", "10/10"
    };
    public List<string> MediaTypes { get; } = new() { "Movie", "Series" };
    public ObservableCollection<GenreCheckbox> AvailableGenres { get; private set; } = new();

    public ICommand AddCommand { get; }

    public AddMediaEntryViewModel(IServiceProvider serviceProvider, Action onSaveComplete)
    {
        _genreFacade = serviceProvider.GetRequiredService<GenreFacade>();
        _mediaFileFacade = serviceProvider.GetRequiredService<MediaFileFacade>();
        _onSaveComplete = onSaveComplete;

        AddCommand = new Command(async () => await OnAddAsync());
        LoadGenresAsync().GetAwaiter().GetResult();
    }

    private async Task LoadGenresAsync()
    {
        try
        {
            var genres = await _genreFacade.GetAllAsync();
            AvailableGenres = new ObservableCollection<GenreCheckbox>(
                genres.Select(g => new GenreCheckbox
                {
                    Id = g.Id,
                    Name = g.Name,
                    IsSelected = false
                }));
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading genres", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to load genres: {ex.Message}", "OK");
        }
    }

    private async Task OnAddAsync()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                await AlertDisplay.ShowAlertAsync("Error", "Media name is required.", "OK");
                return;
            }

            var mediaFileModel = new MediaFileModel
            {
                Id = 0,
                Name = Name,
                Rating = Rating,
                ReleaseDate = int.TryParse(ReleaseYear, out var releaseYear) ? releaseYear : 0,
                Duration = int.TryParse(LengthOrEpisodes.Split(' ')[0], out var duration) ? duration : 0,
                Director = Director,
                Description = Description,
                URL = MediaUrl,
                Favourite = Favourite,
                Status = MediaStatus.Watching,
                Review = Review,
                MediaType = SelectedMediaType == "Movie" ? MediaType.Movie : MediaType.Series
            };

            var savedMedia = await _mediaFileFacade.SaveAsync(mediaFileModel);

            foreach (var genre in AvailableGenres)
            {
                if (genre.IsSelected)
                {
                    await _mediaFileFacade.AddGenreToMediaAsync(savedMedia.Id, genre.Id);
                }
            }

            Logger.Debug(GetType(),
                $"New media added with ID {savedMedia.Id}: {savedMedia.Name}, {savedMedia.Rating}, {savedMedia.ReleaseDate}");
            await AlertDisplay.ShowAlertAsync("Success", "Media item added successfully", "OK");
            _onSaveComplete?.Invoke();
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error creating media", ex);
            await AlertDisplay.ShowAlertAsync("Error", $"Failed to create new media: {ex.Message}", "OK");
        }
    }
}