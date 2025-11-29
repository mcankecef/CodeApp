using CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Commands.DeleteQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Commands.SubmitAnswers;
using CodeApp.Application.Features.QuestionCommandQuery.Commands.UpdateQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetByIdQuestion;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class QuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetAll([FromQuery] int questionLevel, Guid languageId)
    => Ok(await _mediator.Send(new GetAllQuestionQueryRequest(questionLevel, languageId)));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateQuestionCommandRequest request)
    {
        var response = await _mediator.Send(request);

        return StatusCode(201, response);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(UpdateQuestionCommandRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpGet("get-question-by-id/{id}")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _mediator.Send(new GetQuestionByIdQueryRequest(id)));

    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteQuestionCommandRequest(id));

        return NoContent();
    }

    [HttpPost("submit-answers")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> SubmitAnswers(SubmitAnswersCommandRequest request)
    {
        var response = await _mediator.Send(request);
        
        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }

}
