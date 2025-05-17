using Vued.App.Shells;
using Vued.App.Views;
using Vued.App.ViewModels;
// using Vued.BL.Services; // Placeholder for your BL
// using Vued.DAL; // Placeholder for your DAL

namespace Vued.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("materialicons.ttf", "MaterialIcons");
			});

		builder.Services.AddSingleton<App>();
		builder.Services.AddSingleton<AppShell>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainPageViewModel>();

		return builder.Build();
	}
}
