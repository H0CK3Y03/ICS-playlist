using Vued.App.Shells;
using Vued.App.Views;
using Vued.App.ViewModels;
using CommunityToolkit.Maui;
using Vued.App.Views.Filter;
using Vued.App.Views.MediaFile;
using Vued.DAL.Repositories;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.BL.Services;

namespace Vued.App;
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

        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();

        builder.Services.AddTransient<FilterPopup>();
        builder.Services.AddTransient<FilterPopupViewModel>();

        builder.Services.AddTransient<MediaDetailPage>();
        builder.Services.AddTransient<MediaDetailViewModel>();

        builder.Services.AddTransient<MediaEditPopup>();
        builder.Services.AddTransient<MediaEditViewModel>();

        builder.Services.AddScoped<IRepository<Movie>, Repository<Movie>>();
        builder.Services.AddScoped<IEntityMapper<Movie>, MovieEntityMapper>();
        builder.Services.AddScoped<MovieService>();

        return builder.Build();
    }
}
