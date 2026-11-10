using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.Auth;
using H5MauiApp.Pages.MyTripsPage;
using H5MauiApp.Pages.SignupPage;

namespace H5MauiApp.Pages.LoginPage;

public partial class LoginViewModel(HttpClient httpClient, TokenStore tokenStore) : ObservableObject
{
    [ObservableProperty] private string passwordInput = string.Empty;

    [ObservableProperty] private string usernameInput = string.Empty;


    [RelayCommand]
    public async Task Login()
    {
        var request = new LoginRequest(UsernameInput, PasswordInput);
        var res = await httpClient.PostAsJsonAsync("/Login", request);

        if (res.IsSuccessStatusCode is false)
        {
            // todo show error
            return;
        }

        var token = await res.Content.ReadFromJsonAsync<AccessTokenResponse>();

        if (token is null)
        {
            // todo show error 
            return;
        }

        await tokenStore.SaveAsync(token);

        await Shell.Current.GoToAsync("//MyTrips");
        // await Shell.Current.GoToAsync(nameof(MyTripsView));


        // todo error handling 
    }
}

public record LoginRequest(string Username, string Password);