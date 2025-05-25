using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Vued.BL.Facades;

namespace Vued.App.ViewModels;

public class MediaEditViewModel : BindableObject
{
    private string _name;
    private readonly MediaItem _mediaItem;
    private readonly IServiceProvider _serviceProvider;
    private ObservableCollection<string> _ratings;
    private string _selectedRating;
    private string _releaseYear;
    private string _lengthOrEpisodes;
    private string _director;
    private string _genres;
    private string _description;
    private string _review;

    public MediaEditViewModel(MediaItem mediaItem, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _mediaItem = mediaItem;
        Name = mediaItem.Name;
        Ratings = new ObservableCollection<string> { "1/10", "2/10", "3/10", "4/10", "5/10", "6/10", "7/10", "8/10", "9/10", "10/10" };
        // Default, to be replaced with DAL data
        SelectedRating = "10/10"; 
        ReleaseYear = "1999";
        LengthOrEpisodes = "1h 20min / 22 episodes";
        Director = "Director Name";
        Genres = "Fantasy, Horror, Sci-fi";
        Description = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";
        Review = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";

        DeleteCommand = new Command(async () => await OnDelete());
    }

    public ICommand DeleteCommand { get; }

    private async Task OnDelete()
    {
        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediaFileFacade = scope.ServiceProvider.GetService<MediaFileFacade>();
                if (mediaFileFacade == null)
                {
                    System.Diagnostics.Debug.WriteLine("[]MediaFileFacade could not be resolved.");
                    throw new InvalidOperationException("[]MediaFileFacade could not be resolved.");
                }

                // Use the MediaItem's ID for deletion
                await mediaFileFacade.DeleteAsync(_mediaItem.Id);

                // Show success message and navigate back
                await Application.Current.MainPage.DisplayAlert("Success", "Media item deleted successfully.", "OK");
                await Shell.Current.GoToAsync(".."); // Navigate back to the previous page
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[]Error deleting media: {ex.Message}\nStackTrace: {ex.StackTrace}");
            await Application.Current.MainPage.DisplayAlert("[]Error", $"Failed to delete media: {ex.Message}", "OK");
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
}
