using System.Security.Claims;
using H5FlightApi.Auth.Requests.SignUp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wolverine;
using LoginRequest = H5FlightApi.Auth.Requests.Login.LoginRequest;

namespace H5FlightApi.Auth;

[AllowAnonymous]
[ApiController]
[Route("[controller]/auth")]
public class AuthController(IMessageBus mediator) : ControllerBase
{
    [HttpPost("/Login")]
    public async Task<IResult> Login([FromBody] LoginRequest loginRequest)
    {
        return await mediator.InvokeAsync<IResult>(loginRequest);
    }

    [HttpPost("/SignUp")]
    public async Task<IResult> SignUp([FromBody] SignUpRequest signUpRequest)
    {
        return await mediator.InvokeAsync<IResult>(signUpRequest);
    }
}

public static class AuthHelper
{
    public static IResult CreateTokenResponse(Guid id)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
        };

        var identity = new ClaimsIdentity(claims, BearerTokenDefaults.AuthenticationScheme);

        return Results.SignIn(new ClaimsPrincipal(identity), new AuthenticationProperties(), BearerTokenDefaults.AuthenticationScheme);
    }
}