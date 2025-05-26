namespace Vued.App.Utilities;

public static class Logger
{
    public static void Error(Type classType, string message, Exception ex)
    {
        System.Diagnostics.Debug.WriteLine($"[{classType.Name}]: {message}: {ex.Message}\nStackTrace: {ex.StackTrace}");
    }

    public static void Debug(Type classType, string message)
    {
        System.Diagnostics.Debug.WriteLine($"[{classType.Name}]: {message}");
    }
}