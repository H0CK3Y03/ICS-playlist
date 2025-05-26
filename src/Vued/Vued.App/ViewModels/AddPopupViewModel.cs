using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Vued.App.Views.MediaFile;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.App.ViewModels;
public class AddPopupViewModel
{
    private readonly IServiceProvider _serviceProvider;
    private MediaItem _emptyMediaItem;
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

    public AddPopupViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _emptyMediaItem = new MediaItem
        {
            Id = 99,
            Name = string.Empty,
            Rating = "0/10",
            ReleaseDate = 0,
            Duration = 0,
            Director = string.Empty,
            GenreNames = new List<string>(),
            Description = string.Empty,
            URL = string.Empty,
            Favourite = false,
            Status = MediaStatus.Watching,
            MediaType = MediaType.Movie
        };
        AddMediaEntryCommand = new Command(async () => await OnAddMediaEntry());
    }

    public ICommand AddMediaEntryCommand { get; }

    private async Task OnAddMediaEntry()
    {
        if (Application.Current?.MainPage != null)
        {
            if (Application.Current?.MainPage != null)
            {
                var viewModel = new MediaEditViewModel(_emptyMediaItem, _serviceProvider);
                var popup = new MediaEditPopup(viewModel);
                var result = await Application.Current.MainPage.ShowPopupAsync(popup);
                if (result != null)
                {
                }
            }
        }
    }
}
