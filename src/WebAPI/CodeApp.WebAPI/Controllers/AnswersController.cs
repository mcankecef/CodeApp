using CodeApp.Application.Features.AnswerCommandQuery.Commands.CreateAnswer;
using CodeApp.Application.Features.AnswerCommandQuery.Commands.DeleteAnswer;
using CodeApp.Application.Features.AnswerCommandQuery.Queries.GetAllAnswer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AnswersController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnswersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllAnswerQueryRequest()));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateAnswerCommandRequest request)
    {
        var response = await _mediator.Send(request);

        return StatusCode(201, response);
    }
    
    [HttpPatch("{questionId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid questionId)
    {
        await _mediator.Send(new DeleteAnswerCommandRequest(questionId));

        return NoContent();
    }
}
