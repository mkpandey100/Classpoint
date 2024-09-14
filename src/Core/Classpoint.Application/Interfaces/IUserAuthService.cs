using ClassPoint.Application.Dto.UserDto;
using ClassPoint.Domain.Interfaces;

namespace ClassPoint.Application.Interfaces;

public interface IUserAuthService : IScopedService
{
    Task<AuthenticationResponseDto> AuthenticateAsync(AuthenticationRequestDto request);
}