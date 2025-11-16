using CodeApp.Application.Dtos.Streak;
using CodeApp.Application.Features.Queries.Streak.GetMyStreak;
using CodeApp.Application.Features.Queries.Streak.GetUserStreak;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class StreakController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StreakController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("MyStreak")]
        public async Task<IActionResult> GetMyStreak()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var query = new GetMyStreakQuery(userId);
            var result = await _mediator.Send(query);
            
            return Ok(result);
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetUserStreak([FromRoute] string userId)
        {
            var query = new GetUserStreakQuery(userId);
            var result = await _mediator.Send(query);
            
            return Ok(result);
        }
    }
}