using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Vued.App.Shells;
using Vued.App.ViewModels;
using Vued.App.Views;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.App.Views.Watchlist;
using Vued.App.Utilities;
using Vued.BL.Facades;
using Vued.BL.Mappers;
using Vued.BL.Models;
using Vued.DAL;
using Vued.DAL.Entities;
using FFImageLoading.Maui;

namespace Vued.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseFFImageLoading()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("materialicons.ttf", "MaterialIcons");
                fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                fonts.AddFont("Rubik-Bold.ttf", "RubikBold");
                fonts.AddFont("Rajdhani-Regular.ttf", "RajdhaniRegular");
                fonts.AddFont("Rajdhani-Bold.ttf", "RajdhaniBold");
            });

        // Database configuration (SQLite)
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\.."));
            string dbPath = Path.Combine(projectRoot, "app.db");
            options.UseSqlite($"Data Source={dbPath}");
            System.Diagnostics.Debug.WriteLine($"[AHHH]database: {dbPath}");
        });

        // Business layer registrations (Facades and Mappers)
        builder.Services.AddScoped<MediaFileFacade>();
        builder.Services.AddScoped<GenreFacade>();
        builder.Services.AddScoped<WatchlistFacade>();

        builder.Services.AddScoped<GenreModelMapper>();
        builder.Services.AddScoped<IModelMapper<Genre, GenreModel>, GenreModelMapper>();

        builder.Services.AddScoped<MediaFileModelMapper>();
        builder.Services.AddScoped<IModelMapper<MediaFile, MediaFileModel>, MediaFileModelMapper>();

        builder.Services.AddScoped<WatchlistModelMapper>();
        builder.Services.AddScoped<IModelMapper<Watchlist, WatchlistModel>, WatchlistModelMapper>();

        // App and shell
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<AppShell>();

        // Views and view-models
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();

        // Filters
        builder.Services.AddTransient<FilterPopup>();
        builder.Services.AddTransient<FilterPopupViewModel>();

        // Add
        builder.Services.AddTransient<AddPopupViewModel>();
        builder.Services.AddTransient<AddMediaEntryViewModel>();
        builder.Services.AddTransient<AddWatchlistViewModel>();

        // Media Files
        builder.Services.AddTransient<MediaDetailPage>();
        builder.Services.AddTransient<MediaDetailViewModel>();

        builder.Services.AddTransient<MediaEditPopup>();
        builder.Services.AddTransient<MediaEditViewModel>();

        // Watchlists
        builder.Services.AddTransient<WatchlistDetail>();
        builder.Services.AddTransient<WatchlistDetailViewModel>();
        builder.Services.AddTransient<WatchlistEditPopup>();
        builder.Services.AddTransient<WatchlistEditViewModel>();

        var app = builder.Build();

        // Apply migrations at startup
        try
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(typeof(MauiProgram), "Migration failed", ex);
            System.Diagnostics.Debug.WriteLine($"Migration failed: {ex.Message}\nStackTrace: {ex.StackTrace}");
            throw;
        }

        return app;
    }
}
