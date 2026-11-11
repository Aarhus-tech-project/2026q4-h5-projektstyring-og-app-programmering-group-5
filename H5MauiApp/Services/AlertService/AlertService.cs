using System.Net;
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

        if (response.StatusCode == HttpStatusCode.BadRequest && TryParseValidationErrors(message, out var errors))
        {
            title = AlertTitle.ValidationError;
            message = string.Join(Environment.NewLine, errors.Values.SelectMany(m => m));
        }

        await Shell.Current.DisplayAlertAsync(title.ToString(), message, "Close");
    }

    private static bool TryParseValidationErrors(string json, out Dictionary<string, string[]> errors)
    {
        errors = JsonSerializer.Deserialize<ValidationErrorResponse>(json)?.Errors ?? [];
        return errors.Count > 0;
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