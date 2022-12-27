using CodeApp.Application.Features.UserCommandQuery.Commands.CreateUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost,Route("Create")]
        public async Task<IActionResult> Create(CreateUserCommandRequest createUserCommandRequest)
        {
            var result = await _mediator.Send(createUserCommandRequest);

            return StatusCode(201, result);
        }
    }
}
