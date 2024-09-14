namespace ClassPoint.Application.Dto.UserDto;

public class AuthenticationResponseDto
{
    public string AccessToken { get; set; }
    public int ExpiresIn { get; set; }
    public string RefreshToken { get; set; }
}