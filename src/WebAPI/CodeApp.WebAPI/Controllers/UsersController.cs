using CodeApp.Application.Features.UserCommandQuery.Commands.DeleteUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateScore;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserAvatar;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetByUserId;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetLanguageLeaderboard;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetUserScore;
using CodeApp.Application.Features.UserCommandQuery.Commands.BanUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UnbanUser;
using CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserRole;
using CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1, 
        [FromQuery] int size = 10,
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? role = null,
        [FromQuery] bool? isActive = null)
    {
        var request = new GetAllUsersQueryRequest
        {
            Page = page,
            Size = size,
            SearchTerm = searchTerm,
            Role = role,
            IsActive = isActive
        };

        var response = await _mediator.Send(request);
        
        if (response.IsSuccess)
            return Ok(response);
        
        return BadRequest(response);
    }

    [HttpPut("update-score")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> UpdateScore(UpdateScoreCommandRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpGet("get-score/{userId}")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetScore(string userId)
        => Ok(await _mediator.Send(new GetAllUserScoreQueryRequest(userId)));

    [HttpGet("get-by-id/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(string userId)
        => Ok(await _mediator.Send(new GetUserByIdQueryRequest(userId)));

    [HttpGet("me")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        return Ok(await _mediator.Send(new GetUserByIdQueryRequest(userId)));
    }

    [HttpPut]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> Update(UpdateUserCommandRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpDelete("{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(string userId)
    {
        await _mediator.Send(new DeleteUserCommandRequest(userId));

        return NoContent();
    }

    [HttpPut("update-avatar")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> UpdateAvatar(UpdateUserAvatarCommandRequest request)
        => Ok(await _mediator.Send(request));

    [HttpGet("leaderboard/{languageId}")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetLanguageLeaderboard(Guid languageId, [FromQuery] int page = 1, [FromQuery] int pageSize = 5)
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        var request = new GetScoreLeaderboardQueryRequest(languageId, page, pageSize, currentUserId);
        return Ok(await _mediator.Send(request));
    }

    [HttpPost("{userId}/ban")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> BanUser(string userId, [FromBody] BanUserCommandRequest request)
    {
        request.UserId = userId;
        var response = await _mediator.Send(request);
        
        if (response.IsSuccess)
            return Ok(response);
        
        return BadRequest(response);
    }

    [HttpPost("{userId}/unban")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UnbanUser(string userId)
    {
        var request = new UnbanUserCommandRequest { UserId = userId };
        var response = await _mediator.Send(request);
        
        if (response.IsSuccess)
            return Ok(response);
        
        return BadRequest(response);
    }

    [HttpPut("{userId}/roles")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateUserRole(string userId, [FromBody] UpdateUserRoleCommandRequest request)
    {
        request.UserId = userId;
        var response = await _mediator.Send(request);
        
        if (response.IsSuccess)
            return Ok(response);
        
        return BadRequest(response);
    }
}
