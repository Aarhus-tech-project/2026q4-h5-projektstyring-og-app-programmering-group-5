using FluentValidation;
using H5FlightApi.Persistence;
using H5FlightApi.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace H5FlightApi.Auth.Requests.SignUp;

public record SignUpRequest(string Username, string Password);

public class SignUpRequestHandler(AppDbContext appDbContext, IValidator<SignUpRequest> validator, CancellationToken cancellationToken)
{
    public async Task<IResult> Handle(SignUpRequest request)
    {
        var isValid = await validator.ValidateAsync(request, cancellationToken);

        if (!isValid.IsValid)
        {
            return Results.BadRequest(isValid.Errors);
        }

        // TODO En factory giver god mening her da dder er logik releteret til creation af bruger. Kombiner med smartere løsning tikl enforceent af unik username. 
        // fx en custom exception der kan kastes af ef core. men for nu lavver jeg et simplet user check. Skalere mega lort men det kan skiftes ud senere

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

        // todo logging 

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