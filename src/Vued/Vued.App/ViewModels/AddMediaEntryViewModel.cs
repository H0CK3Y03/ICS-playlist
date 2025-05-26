using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.App.ViewModels;

public class AddMediaEntryViewModel
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Action _onSaveComplete;

    // Properties bound to the XAML
    public string Name { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string LengthOrEpisodes { get; set; } = string.Empty;
    public string Rating { get; set; } = "0/10";
    public string ImageUrl { get; set; } = string.Empty;
    public GenreModel SelectedGenre { get; set; } // Changed from string to GenreModel
    public string ReleaseYear { get; set; } = string.Empty;
    public string MediaUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Review { get; set; } = string.Empty;
    public bool Favourite { get; set; } = false;
    public string SelectedMediaType { get; set; } = "Movie";

    // Data sources for pickers
    public List<string> Ratings { get; } = new List<string>
    {
        "0/10", "1/10", "2/10", "3/10", "4/10", "5/10",
        "6/10", "7/10", "8/10", "9/10", "10/10"
    };
    public List<string> MediaTypes { get; } = new List<string> { "Movie", "Series" };
    public List<GenreModel> AvailableGenres { get; private set; } = new List<GenreModel>();

    public ICommand AddCommand { get; }

    public AddMediaEntryViewModel(IServiceProvider serviceProvider, Action onSaveComplete)
    {
        _serviceProvider = serviceProvider;
        _onSaveComplete = onSaveComplete;
        AddCommand = new Command(async () => await OnAddAsync());
        LoadGenresAsync().GetAwaiter().GetResult(); // Load genres during initialization
    }

    private async Task LoadGenresAsync()
    {
        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var genreFacade = scope.ServiceProvider.GetService<GenreFacade>();
                if (genreFacade != null)
                {
                    AvailableGenres = (await genreFacade.GetAllAsync()).ToList();
                    if (AvailableGenres.Any() && SelectedGenre == null)
                    {
                        SelectedGenre = AvailableGenres[0]; // Now valid, as both are GenreModel
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading genres: {ex.Message}");
        }
    }

    private async Task OnAddAsync()
    {
        try
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Media name is required.", "OK");
                return;
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediaFileFacade = scope.ServiceProvider.GetService<MediaFileFacade>();
                if (mediaFileFacade == null)
                {
                    System.Diagnostics.Debug.WriteLine("MediaFileFacade could not be resolved.");
                    throw new InvalidOperationException("MediaFileFacade could not be resolved.");
                }

                // Create MediaFileModel
                var mediaFileModel = new MediaFileModel
                {
                    Id = 0,
                    Name = Name,
                    Rating = Rating,
                    ReleaseDate = int.TryParse(ReleaseYear, out int releaseYear) ? releaseYear : 0,
                    Duration = int.TryParse(LengthOrEpisodes.Split(' ')[0], out int duration) ? duration : 0,
                    Director = Director,
                    // Replace this with genre to mediafile linking
                    //Genres = SelectedGenre != null ? new List<string> { SelectedGenre.Name } : new List<string>(),
                    Description = Description,
                    URL = MediaUrl,
                    Favourite = Favourite,
                    Status = MediaStatus.Watching,
                    MediaType = SelectedMediaType == "Movie" ? MediaType.Movie : MediaType.Series
                };

                // Save to database
                await mediaFileFacade.SaveAsync(mediaFileModel);
                System.Diagnostics.Debug.WriteLine(
                    $"New media added with ID {mediaFileModel.Id}: {mediaFileModel.Name}, {mediaFileModel.Rating}, {mediaFileModel.ReleaseDate}"
                );

                // Close the popup and return the saved model
                await Application.Current.MainPage.DisplayAlert("Success", "Media item added successfully.", "OK");
                _onSaveComplete?.Invoke();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error creating media: {ex.Message}\nStackTrace: {ex.StackTrace}");
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to create new media: {ex.Message}", "OK");
            }
        }
    }
}