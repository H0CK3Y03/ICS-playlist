using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vued.App.Shells;
using Vued.App.ViewModels;
using Vued.App.Views;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.BL.Facades;
using Vued.BL.Mappers;
using Vued.BL.Models;
using Vued.DAL;
using Vued.DAL.Entities;

namespace Vued.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
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
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db");
                options.UseSqlite($"Data Source={dbPath}");
            });

            // Business layer registrations (Facades and Mappers)
            builder.Services.AddScoped<MediaFileFacade>();
            builder.Services.AddScoped<IModelMapper<MediaFile, MediaFileModel>, MediaFileModelMapper>();
            builder.Services.AddScoped<GenreFacade>();
            builder.Services.AddScoped<IModelMapper<Genre, GenreModel>, GenreModelMapper>();
            builder.Services.AddScoped<MovieFacade>();
            builder.Services.AddScoped<SeriesFacade>();
            builder.Services.AddScoped<WatchlistFacade>();
            builder.Services.AddScoped<IModelMapper<Watchlist, WatchlistModel>, WatchlistModelMapper>();

            // App and shell
            builder.Services.AddSingleton<App>();
            builder.Services.AddSingleton<AppShell>();

            // Views and view-models
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<FilterPopup>();
            builder.Services.AddTransient<FilterPopupViewModel>();
            builder.Services.AddTransient<MediaDetailPage>();
            builder.Services.AddTransient<MediaDetailViewModel>();
            builder.Services.AddTransient<MediaEditPopup>();
            builder.Services.AddTransient<MediaEditViewModel>();

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
                System.Diagnostics.Debug.WriteLine($"Migration failed: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }

            return app;
        }
    }
}
