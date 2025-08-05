using CodeApp.Application.Features.AuthCommandQuery.LoginUser;
using CodeApp.Application.Features.AuthCommandQuery.RefreshToken;
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

    [HttpPost, Route("Login")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        => Ok(await _mediator.Send(loginUserCommandRequest));

    [HttpPost, Route("RefreshTokenLogin")]
    public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        => Ok(await _mediator.Send(refreshTokenLoginCommandRequest));

    [HttpPost, Route("Register")]
    public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
    {
        createUserCommandRequest.AvatarId = _defaultAvatarId;
        var result = await _mediator.Send(createUserCommandRequest);

        return Ok(result);
    }
}
