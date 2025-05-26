using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.App.ViewModels;

public class AddMediaEntryViewModel
{
    private readonly IServiceProvider _serviceProvider;

    // Properties bound to the XAML
    public string Name { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string LengthOrEpisodes { get; set; } = string.Empty;
    public string Rating { get; set; } = "0/10";
    public string ImageUrl { get; set; } = string.Empty;
    public string Genres { get; set; } = string.Empty;
    public string ReleaseYear { get; set; } = string.Empty;
    public string MediaUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Review { get; set; } = string.Empty;

    // Ratings list for the Picker
    public List<string> Ratings { get; } = new List<string>
    {
        "0/10", "1/10", "2/10", "3/10", "4/10", "5/10",
        "6/10", "7/10", "8/10", "9/10", "10/10"
    };

    public ICommand AddCommand { get; }

    public AddMediaEntryViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        AddCommand = new Command(async () => await OnAddAsync());
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
                    Description = Description,
                    URL = MediaUrl,
                    Favourite = false,
                    Status = MediaStatus.Watching,
                    MediaType = MediaType.Movie
                };

                // Save to database
                await mediaFileFacade.SaveAsync(mediaFileModel);
                System.Diagnostics.Debug.WriteLine(
                    $"New media added with ID {mediaFileModel.Id}: {mediaFileModel.Name}, {mediaFileModel.Rating}, {mediaFileModel.ReleaseDate}"
                );

                await Application.Current.MainPage.DisplayAlert("Success", "Media item added successfully.", "OK");
                await Shell.Current.GoToAsync("..");
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