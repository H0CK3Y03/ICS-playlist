using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Vued.App.ViewModels;

public class MediaEditViewModel : BindableObject
{
    private string _name;
    private ObservableCollection<string> _ratings;
    private string _selectedRating;
    private string _releaseYear;
    private string _lengthOrEpisodes;
    private string _director;
    private string _genres;
    private string _description;
    private string _review;

    public MediaEditViewModel(MediaItem mediaItem)
    {
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
