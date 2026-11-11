using System.Text.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Maui.Core;

namespace H5MauiApp.Services.AlertService;

public class AlertService : IAlertService
{
    public async Task ShowAlert(AlertTitle title, string message)
    {
        await Shell.Current.DisplayAlertAsync(title.ToString(), message, "Close");
    }

    public async Task ShowHttpErrorAlert(HttpResponseMessage response)
    {
        var message = await response.Content.ReadAsStringAsync();
        var title = AlertTitle.Error;

        var validationResponse = JsonSerializer.Deserialize<ValidationErrorResponse>(message);

        if (validationResponse?.Errors is { Count: > 0 } errors)
        {
            title = AlertTitle.ValidationError;

            message = string.Join(
                Environment.NewLine,
                errors.Values.SelectMany(messages => messages)
            );
        }

        await Shell.Current.DisplayAlertAsync(title.ToString(), message, "Close");
    }
}

public enum AlertTitle
{
    Error,
    ValidationError
}

// todo moev 
public class ValidationErrorResponse
{
    [JsonPropertyName("errors")] public Dictionary<string, string[]>? Errors { get; set; }
}