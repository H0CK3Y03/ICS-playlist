using Vued.App.Shells;
using Microsoft.Extensions.DependencyInjection;

namespace Vued.App;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        MainPage = serviceProvider.GetService<AppShell>();
    }
}