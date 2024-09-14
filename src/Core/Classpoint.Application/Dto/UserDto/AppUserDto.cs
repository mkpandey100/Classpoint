using System.Security.Claims;

namespace ClassPoint.Application.Dto.UserDto;

public class AppUserDto : ClaimDto
{
    public ClaimsIdentity ClaimsIdentity { get; set; }
}