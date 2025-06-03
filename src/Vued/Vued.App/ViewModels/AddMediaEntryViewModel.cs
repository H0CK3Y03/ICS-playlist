using System.Windows.Input;
using Vued.App.Utilities;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;

// TODO: Link Genre id with Media id to create connection in db

namespace Vued.App.ViewModels;

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
    public GenreModel SelectedGenre { get; set; }
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
    public List<GenreModel> AvailableGenres { get; private set; } = new();

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
            AvailableGenres = (await _genreFacade.GetAllAsync()).ToList();
            if (AvailableGenres.Any() && SelectedGenre == null)
            {
                SelectedGenre = AvailableGenres[0];
            }
        }
        catch (Exception ex)
        {
            Logger.Error(GetType(), "Error loading genres", ex);
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

            await _mediaFileFacade.SaveAsync(mediaFileModel);

            Logger.Debug(GetType(),
                $"New media added with ID {mediaFileModel.Id}: {mediaFileModel.Name}, {mediaFileModel.Rating}, {mediaFileModel.ReleaseDate}"
            );
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
