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

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            var result = await _mediator.Send(loginUserCommandRequest);

            return Ok(result);
        }

        [HttpPost, Route("RefreshTokenLogin")]
        public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            var result = await _mediator.Send(refreshTokenLoginCommandRequest);

            return Ok(result);
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
        {
            var result = await _mediator.Send(createUserCommandRequest);

            return Ok(result);
        }

    }
}
