using CodeApp.Application.Features.UserCommandQuery.Commands.DeleteUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateScore;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserAvatar;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUser;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetByUserId;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetLanguageLeaderboard;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetUserScore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllUserQueryRequest()));

    [HttpPut, Route("UpdateScore")]
    public async Task<IActionResult> UpdateScore(UpdateScoreCommandRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpGet, Route("GetScore/{userId}")]
    public async Task<IActionResult> GetScore(string userId)
        => Ok(await _mediator.Send(new GetAllUserScoreQueryRequest(userId)));

    [HttpGet, Route("GetById/{userId}")]
    public async Task<IActionResult> GetById(string userId)
        => Ok(await _mediator.Send(new GetUserByIdQueryRequest(userId)));

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

    [HttpPut, Route("updateAvatar")]
    public async Task<IActionResult> UpdateAvatar(UpdateUserAvatarCommandRequest request)
        => Ok(await _mediator.Send(request));

    [HttpGet, Route("leaderboard/{languageId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetLanguageLeaderboard(Guid languageId, [FromQuery] int page = 1, [FromQuery] int pageSize = 5)
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        var request = new GetScoreLeaderboardQueryRequest(languageId, page, pageSize, currentUserId);
        return Ok(await _mediator.Send(request));
    }
}
