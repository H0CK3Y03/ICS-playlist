namespace Vued.App.Utilities;

public class AlertDisplay
{
    private readonly Page _page;

    public AlertDisplay(Page page)
    {
        _page = page ?? throw new ArgumentNullException(nameof(page));
    }

    public async Task ShowAlertAsync(string title, string message, string cancel)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (_page != null)
            {
                await _page.DisplayAlert(title, message, cancel);
            }
        });
    }
}