using System.Security.Claims;

namespace H5FlightApi.Services.CurrentUserService;

// IMPORTANT NOTE: DO NOT USE CurrentUserService IN CONTROLLERS OR ENDPOINTS MARKED AS ALLOW ANONYMOUS.
// AS THIS SERVICE REQUIRES AN AUTH TOKEN TO BE PRESENT
public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public ClaimsPrincipal? User => httpContextAccessor.HttpContext?.User;

    public Guid? UserId
    {
        get
        {
            var claim = User?.FindFirstValue(
                ClaimTypes.NameIdentifier
            );

            return Guid.TryParse(claim, out var userId)
                ? userId
                : null;
        }
    }
}