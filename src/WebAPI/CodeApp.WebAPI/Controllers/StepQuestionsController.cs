using CodeApp.Application.Features.StepQuestionCommandQuery.Queries.GetStepQuestions;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetQuestionsByStep;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class StepQuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StepQuestionsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetStepQuestions(
        [FromQuery] Guid languageId,
        [FromQuery] string userId)
    {
        var request = new GetStepQuestionsQueryRequest
        {
            LanguageId = languageId,
            AppUserId = userId
        };
        
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{stepQuestionId}/Questions")]
    public async Task<IActionResult> GetQuestionsByStep(Guid stepQuestionId, [FromQuery] Guid languageId, [FromQuery] string appUserId)
    {
        var request = new GetQuestionsByStepQueryRequest
        {
            StepQuestionId = stepQuestionId,
            LanguageId = languageId,
            AppUserId = appUserId
        };
        
        var response = await _mediator.Send(request);
        
        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }
}