using FluentValidation;
using H5FlightApi.Persistence;
using H5FlightApi.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Auth.Requests.SignUp;

public record SignUpRequest(string Username, string Password);

public class SignUpRequestHandler(AppDbContext appDbContext, IValidator<SignUpRequest> validator)
{
    public async Task<IResult> Handle(SignUpRequest request)
    {
        var isValid = await validator.ValidateAsync(request);

        if (!isValid.IsValid)
        {
            return Results.BadRequest(isValid.Errors);
        }


        // Would make sence to use a combination of a factory fro creating the user as logic is required/related to the creaton. 
        // Make some database rule that makes username unique, and throw custom error if its not, catch the error and return response. 
        // current solution scales terrrible but works fine for now. 
        var users = await appDbContext.Users.ToListAsync();

        foreach (var user in users)
        {
            if (user.UserName == request.Username)
            {
                return Results.BadRequest("Username already in use");
            }
        }

        var newUser = new User
        {
            UserName = request.Username,
            Password = "password"
        };

        var passwordHash = new PasswordHasher<User>().HashPassword(newUser, request.Password);

        newUser.Password = passwordHash;

        await appDbContext.Users.AddAsync(newUser);
        await appDbContext.SaveChangesAsync();

        return AuthHelper.CreateTokenResponse(newUser.Id);
    }

    public class SignUpRequestHandlerValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpRequestHandlerValidator()
        {
            RuleFor(r => r.Username).NotEmpty();
            RuleFor(r => r.Password).MinimumLength(8).MaximumLength(50).NotEmpty();
        }
    }
}