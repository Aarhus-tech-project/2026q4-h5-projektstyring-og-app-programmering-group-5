namespace H5MauiApp.Services.AlertService;

public interface IAlertService
{
    Task ShowAlert(AlertTitle title, string message);
    Task ShowHttpErrorAlert(HttpResponseMessage response);
}