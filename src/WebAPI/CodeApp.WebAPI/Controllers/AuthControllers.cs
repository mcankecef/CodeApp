using CodeApp.Application.Features.UserCommandQuery.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthControllers(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            var result = await _mediator.Send(loginUserCommandRequest);

            return Ok(result);
        }

    }
}
