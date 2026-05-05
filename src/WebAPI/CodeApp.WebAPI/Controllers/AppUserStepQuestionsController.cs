using CodeApp.Application.Features.AppUserStepQuestionCommandQuery.Queries.GetUserStepQuestions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AppUserStepQuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppUserStepQuestionsController(IMediator mediator) => _mediator = mediator;

    [HttpGet("user-progress")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetUserStepQuestions(
        [FromQuery] Guid languageId,
        [FromQuery] string userId)
    {
        var request = new GetUserStepQuestionsQueryRequest
        {
            LanguageId = languageId,
            AppUserId = userId
        };
        
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
