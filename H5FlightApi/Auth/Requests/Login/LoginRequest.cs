using FluentValidation;
using H5FlightApi.Persistence;
using H5FlightApi.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Auth.Requests.Login;

public record LoginRequest(string Username, string Password);

public class LoginRequestHandler(AppDbContext appDbContext, IValidator<LoginRequest> validator)
{
    public async Task<IResult> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var isValid = await validator.ValidateAsync(request, cancellationToken);

        if (isValid.IsValid is false)
        {
            return Results.ValidationProblem(isValid.ToDictionary());
        }

        var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserName == request.Username, cancellationToken);

        if (user is null)
        {
            return Results.NotFound("Could not find user with given username");
        }

        var passwordHasher = new PasswordHasher<User>();

        var result = passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return Results.Unauthorized();
        }

        return AuthHelper.CreateTokenResponse(user.Id);
    }

    public class LoginRequestHandlerValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestHandlerValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}