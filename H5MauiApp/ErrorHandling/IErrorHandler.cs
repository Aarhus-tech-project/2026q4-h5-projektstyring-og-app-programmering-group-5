using Microsoft.Extensions.Logging;

namespace H5MauiApp.ErrorHandling;

public interface IErrorHandler
{
    Task HandleAsync(Exception ex);
}

public class AlertErrorHandler(ILogger<AlertErrorHandler> log) : IErrorHandler
{
    public Task HandleAsync(Exception ex)
    {
        log.LogError(ex, "Unhandled exception");
        return Shell.Current.DisplayAlertAsync("Unhandled exception", ex.Message, "Close");
    }
}

public static class ErrorHandlerExtensions
{
    public static async Task Guard(this IErrorHandler errors, Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            await errors.HandleAsync(ex);
        }
    }
}