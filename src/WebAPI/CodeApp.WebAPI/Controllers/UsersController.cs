using CodeApp.Application.Features.UserCommandQuery.Commands.DeleteUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateScore;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserAvatar;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUser;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetByUserId;
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUserQueryRequest());

            return Ok(result);
        }

        [HttpPut, Route("UpdateScore")]
        public async Task<IActionResult> UpdateScore(UpdateScoreCommandRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpGet, Route("GetScore/{userId}")]
        public async Task<IActionResult> GetScore(string userId)
        {
            var result = await _mediator.Send(new GetAllUserScoreQueryRequest(userId));

            return Ok(result);
        }

        [HttpGet, Route("GetById/{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var result = await _mediator.Send(new GetUserByIdQueryRequest(userId));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommandRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            await _mediator.Send(new DeleteUserCommandRequest(userId));

            return NoContent();
        }

        [HttpPut,Route("updateAvatar")]
        public async Task<IActionResult> UpdateAvatar(UpdateUserAvatarCommandRequest request)
        {
            var avatarImageUrl =await _mediator.Send(request);

            return Ok(avatarImageUrl);
        }
    }
}
