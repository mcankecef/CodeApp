using CodeApp.Application.Features.AuthCommandQuery.LoginUser;
using CodeApp.Application.Features.AuthCommandQuery.RefreshToken;
using CodeApp.Application.Features.AuthCommandQuery.GoogleLogin;
using CodeApp.Application.Features.UserCommandQuery.Commands.CreateUser;
using CodeApp.Application.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly Guid _defaultAvatarId;
    private readonly IConfiguration _configuration;

    public AuthController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
        _defaultAvatarId = Guid.Parse(_configuration[SettingNames.DefaultAvatarId]);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        => Ok(await _mediator.Send(loginUserCommandRequest));

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginCommandRequest request)
    {
        var response = await _mediator.Send(request);
        
        if (response.IsSuccess)
            return Ok(response);
            
        return BadRequest(response);
    }

    [HttpPost("refresh-token-login")]
    public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        => Ok(await _mediator.Send(refreshTokenLoginCommandRequest));

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
    {
        createUserCommandRequest.AvatarId = _defaultAvatarId;
        var result = await _mediator.Send(createUserCommandRequest);

        return Ok(result);
    }
}
