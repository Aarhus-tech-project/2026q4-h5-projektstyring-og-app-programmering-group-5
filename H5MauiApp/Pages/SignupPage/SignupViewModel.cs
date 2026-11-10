using System.Diagnostics;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using H5MauiApp.Auth;
using H5MauiApp.Pages.LoginPage;
using H5MauiApp.Pages.MyTripsPage;

namespace H5MauiApp.Pages.SignupPage;

public partial class SignupViewModel(HttpClient httpClient, TokenStore tokenStore) : ObservableObject
{
    [ObservableProperty] private string usernameInput = string.Empty;

    [ObservableProperty] private string passwordInput = string.Empty;

    [RelayCommand]
    public async Task SignUp()
    {
        var request = new SignUpRequest(UsernameInput, PasswordInput);
        var res = await httpClient.PostAsJsonAsync("/SignUp", request);

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

        // await Shell.Current.GoToAsync(nameof(MyTripsView));
        await Shell.Current.GoToAsync("//MyTrips");
        // new ShellNavigationQueryParameters
        // {
        //     ["orderId"] = order.Id
        // });

        // todo error handling 
    }

    [RelayCommand]
    public async Task GoToLoginView() => await Shell.Current.GoToAsync(nameof(LoginView));
}

public record SignUpRequest(string Username, string Password);