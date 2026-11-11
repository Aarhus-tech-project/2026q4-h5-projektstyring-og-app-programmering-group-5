using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.Auth;
using H5MauiApp.ErrorHandling;
using H5MauiApp.Pages.MyTripsPage;
using H5MauiApp.Pages.SignupPage;
using H5MauiApp.Services.AlertService;

namespace H5MauiApp.Pages.LoginPage;

public partial class LoginViewModel(HttpClient httpClient, TokenStore tokenStore, IErrorHandler errorHandler, IAlertService alertService)
    : ObservableObject
{
    [ObservableProperty] private string passwordInput = string.Empty;
    [ObservableProperty] private string usernameInput = string.Empty;

    [RelayCommand]
    public async Task Login() => await errorHandler.Guard(async () =>
    {
        var request = new LoginRequest(UsernameInput, PasswordInput);
        var res = await httpClient.PostAsJsonAsync("/Login", request);

        if (res.IsSuccessStatusCode is false)
        {
            await alertService.ShowHttpErrorAlert(res);
            return;
        }

        var token = await res.Content.ReadFromJsonAsync<AccessTokenResponse>();

        if (token is null)
        {
            await alertService.ShowAlert(AlertTitle.Error, "Could not read token from response");
            return;
        }

        await tokenStore.SaveAsync(token);

        await Shell.Current.GoToAsync("//MyTrips");
    });
}

// todo move 
public record LoginRequest(string Username, string Password);