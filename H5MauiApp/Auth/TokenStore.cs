namespace H5MauiApp.Auth;

public class TokenStore
{
    private const string AccessKey = "access_token";
    private const string RefreshKey = "refresh_token";
    private string? _cached;

    public async Task<string?> GetAccessTokenAsync() =>
        _cached ??= await SecureStorage.Default.GetAsync(AccessKey);

    public async Task SaveAsync(AccessTokenResponse token)
    {
        _cached = token.AccessToken;
        await SecureStorage.Default.SetAsync(AccessKey, token.AccessToken);
        await SecureStorage.Default.SetAsync(RefreshKey, token.RefreshToken);
    }

    public void Clear()
    {
        _cached = null;
        SecureStorage.Default.Remove(AccessKey);
        SecureStorage.Default.Remove(RefreshKey);
    }
}