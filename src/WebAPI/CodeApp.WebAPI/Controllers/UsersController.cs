using CodeApp.Application.Features.UserCommandQuery.Commands.AddScoreToUser;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUser;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetUserScore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _mediator.Send(new GetAllUserQueryRequest());

            return Ok(result);
        }
        [HttpPut,Route("AddScoreToUser")]
        public async Task<IActionResult> UpdateScoreToUser(UpdateScoreToUserCommandRequest updateScoreToUserCommandRequest)
        {
            await _mediator.Send(updateScoreToUserCommandRequest);

            return NoContent();
        }
        [HttpGet,Route("GetUserScore/{userId}")]
        public async Task<IActionResult> GetUserScore(string userId)
        {
            var result = await _mediator.Send(new GetAllUserScoreQueryRequest(userId));

            return Ok(result);
        }
    }
}
