namespace H5MauiApp.Auth;

public record AccessTokenResponse(
    string TokenType,
    string AccessToken,
    long ExpiresIn,
    string RefreshToken
);