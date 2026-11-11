using H5MauiApp.ErrorHandling;

namespace H5MauiApp.Pages.Popups.CreateTrip;

using System.Net.Http.Json;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class CreateTripPopupViewModel(HttpClient httpClient, IErrorHandler errorHandler) : ObservableObject
{
    [ObservableProperty] private string titleInput;

    [RelayCommand]
    public async Task CreateTrip() => await errorHandler.Guard(async () =>
    {
        var response = await httpClient.PostAsJsonAsync("/Trip", new CreateTripRequest(TitleInput));

        // todo husk og tjek validerigs response i styedet for at lukke opouppen 
        // todo kan også bruge validering i frontenden via nuget toolkit 
        if (response.IsSuccessStatusCode is false)
        {
            await Close(CreateTripDialogResults.Error);
            return;
        }

        await Close(CreateTripDialogResults.Success);
    });

    [RelayCommand]
    Task Close(CreateTripDialogResults result)
    {
        return Shell.Current.ClosePopupAsync(result);
    }
}

// todo move 
public record CreateTripRequest(string Title);