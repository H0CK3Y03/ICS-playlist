using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Vued.App.Views.Add;
using Vued.BL.Facades;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.App.ViewModels;

public class AddPopupViewModel
{
    private readonly IServiceProvider _serviceProvider;
    private readonly MainPageViewModel _mainPageViewModel;

    public AddPopupViewModel(IServiceProvider serviceProvider, MainPageViewModel mainPageViewModel)
    {
        _mainPageViewModel = mainPageViewModel;
        _serviceProvider = serviceProvider;
        AddMediaEntryCommand = new Command(async () => await OnAddMediaEntry());
    }

    public ICommand AddMediaEntryCommand { get; }

    private async Task OnAddMediaEntry()
    {
        try
        {
            var popup = new AddMediaEntry(_serviceProvider);
            var result = await Application.Current.MainPage.ShowPopupAsync(popup);
            await _mainPageViewModel.LoadMediaFiles();
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