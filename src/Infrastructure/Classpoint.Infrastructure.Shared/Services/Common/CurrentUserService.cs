using ClassPoint.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ClassPoint.Infrastructure.Shared.Services.Common;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid UserId => GetCurrentUserId();
    public string UserName => GetCurrentUserName();
    public string FullName => GetCurrentFullName();
    public string Role => GetCurrentUserRoleName();

    private string GetCurrentUserRoleName()
    {
        var NameClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Role");
        if (NameClaim != null)
        {
            return NameClaim.Value;
        }
        return string.Empty;
    }

    private Guid GetCurrentUserId()
    {
        var user = _httpContextAccessor.HttpContext.User;

        if (user != null)
        {
            return Guid.TryParse(user.FindFirst(ClassPoint.Domain.Constants.JwtClaimIdentifiers.Id).Value, out Guid usId) ? usId : Guid.Empty;
        }
        return Guid.Empty;
    }

    private string GetCurrentUserName()
    {
        var NameClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username");
        if (NameClaim != null)
        {
            return NameClaim.Value;
        }
        return string.Empty;
    }

    private string GetCurrentFullName()
    {
        var NameClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "fullname");
        if (NameClaim != null)
        {
            return NameClaim.Value;
        }
        return string.Empty;
    }
}