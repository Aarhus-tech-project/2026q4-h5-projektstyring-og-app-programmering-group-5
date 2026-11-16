namespace H5MauiApp.Services.AlertService;

public interface IAlertService
{
    Task ShowAlertAsync(AlertTitle title, string message);
    Task ShowHttpErrorAlertAsync(HttpResponseMessage response);
}