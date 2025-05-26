using Microsoft.Maui.Controls;

namespace Vued.App.Utilities;

public static class AlertDisplay
{
    public static async Task ShowAlertAsync(string title, string message, string cancel)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert(title, message, cancel);
            }
        });
    }
}
