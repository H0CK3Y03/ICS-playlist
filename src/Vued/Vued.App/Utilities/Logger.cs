namespace Vued.App.Utilities;

public class Logger
{
    public void Error(Type classType, string message, Exception ex)
    {
        System.Diagnostics.Debug.WriteLine($"[{classType.Name}]: {message}: {ex.Message}\nStackTrace: {ex.StackTrace}");
    }

    public void Debug(Type classType, string message)
    {
        System.Diagnostics.Debug.WriteLine($"[{classType.Name}]: {message}");
    }
}