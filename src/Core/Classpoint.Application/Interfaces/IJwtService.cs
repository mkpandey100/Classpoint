using ClassPoint.Application.Dto.UserDto;
using ClassPoint.Domain.Interfaces;
using System.Security.Claims;

namespace ClassPoint.Application.Interfaces
{
    public interface IJwtService : IScopedService
    {
        ClaimsIdentity GenerateClaimsIdentity(ClaimDto claimDTO);

        Task<AuthenticationResponseDto> GenerateJwt(AppUserDto userDetails);
    }
}