using System.Security.Claims;

namespace H5FlightApi.Services.CurrentUserService;

public interface ICurrentUserService
{
    ClaimsPrincipal? User { get; }
    Guid? UserId { get; }
}