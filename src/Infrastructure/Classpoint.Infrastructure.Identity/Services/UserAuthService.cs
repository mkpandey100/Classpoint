using ClassPoint.Application.Dto.UserDto;
using ClassPoint.Application.Interfaces;
using ClassPoint.Domain.Entities;
using Serilog;

namespace ClassPoint.Infrastructure.Identity.Extensions
{
    public class UserAuthService(IJwtService jwtService, IUserQueryService userQueryService) : IUserAuthService
    {
        private readonly IUserQueryService _userQueryService = userQueryService;
        private readonly IJwtService _jwtService = jwtService;

        #region AuthToken

        public async Task<AuthenticationResponseDto> AuthenticateAsync(AuthenticationRequestDto request)
        {
            try
            {
                var claimsIdentity = await GetClaimsIdentityAsync(request.UserName, request.Password);
                var authenticationOutput = await _jwtService.GenerateJwt(claimsIdentity);
                var userInfo = await _userQueryService.FindByEmailAsync(request.UserName);
                return authenticationOutput;
            }
            catch (Exception ex)
            {
                Log.Error("Error: {ErrorMessage},{ErrorDetails}", ex.Message, ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Verifies user credentials and returns claim list asynchronously.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<AppUserDto> GetClaimsIdentityAsync(string userName, string password)
        {
            try
            {
                AppUser appUser = await _userQueryService.FindByEmailAsync(userName);
                return appUser == null
                    ? throw new Exception($"No Accounts Registered with {userName}.")
                    : await VerifyUserNamePasswordAsync(password, appUser, new AppUserDto { Id = appUser.Id, Email = appUser.Email });
            }
            catch (Exception ex)
            {
                Log.Error("Error: {ErrorMessage},{ErrorDetails}", ex.Message, ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Verifies username and password and returns claim list asynchronously.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userToVerify"></param>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        private async Task<AppUserDto> VerifyUserNamePasswordAsync(string password, AppUser userToVerify, AppUserDto userDetails)
        {
            if (await _userQueryService.CheckPasswordAsync(userToVerify, password))
            {
                var claimDto = new ClaimDto
                {
                    Id = userToVerify.Id,
                    Email = userToVerify.Email,
                    IsAdmin = await _userQueryService.CheckUserAdminAsync(userToVerify.Id),
                };
                userDetails.ClaimsIdentity = await Task.FromResult(_jwtService.GenerateClaimsIdentity(claimDto));
                return userDetails;
            }

            throw new Exception("Invalid email or password.");
        }

        #endregion AuthToken
    }
}