using Asp.Versioning;
using ClassPoint.API.Controllers;
using ClassPoint.Application.Dto.UserDto;
using ClassPoint.Application.Interfaces;
using ClassPoint.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClassPoint.Api.Controllers.V1.Authentication;

[ApiVersion("1")]
public class AuthenticationController(IUserAuthService authService, IUserCommandService userCommandService) : ApiController
{
    private readonly IUserAuthService _authService = authService;
    private readonly IUserCommandService _userCommandService = userCommandService;

    [AllowAnonymous]
    [HttpPost("token")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequestDto request)
    {
        try
        {
            var result = await _authService.AuthenticateAsync(request);
            return Ok(HandleResult(HttpStatusCode.OK, data: result));
        }
        catch (Exception ex)
        {
            return BadRequest(HandleResult(HttpStatusCode.BadRequest, ex.Message, null));
        }
    }

    [AllowAnonymous]
    [HttpPost("create")]
    public async Task<IActionResult> CreateUserAsync([FromBody] AuthenticationRequestDto request)
    {
        try
        {
            AppUser appUser = new AppUser { UserName = request.UserName, Email = request.UserName };
            var result = await _userCommandService.CreateAsync(appUser, request.Password, "Admin");
            return Ok(HandleResult(HttpStatusCode.OK, data: result));
        }
        catch (Exception ex)
        {
            return BadRequest(HandleResult(HttpStatusCode.BadRequest, ex.Message, null));
        }
    }
}