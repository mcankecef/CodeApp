using CodeApp.Application.Features.AuthCommandQuery.LoginUser;
using CodeApp.Application.Features.AuthCommandQuery.RefreshToken;
using CodeApp.Application.Features.UserCommandQuery.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
            => Ok(await _mediator.Send(loginUserCommandRequest));

        [HttpPost, Route("RefreshTokenLogin")]
        public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
            => Ok(await _mediator.Send(refreshTokenLoginCommandRequest));

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
            => Ok(await _mediator.Send(createUserCommandRequest));

    }
}
