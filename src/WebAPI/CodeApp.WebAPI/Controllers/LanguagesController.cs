using CodeApp.Application.Features.LanguageCommandQuery.Commands.CreateLanguage;
using CodeApp.Application.Features.LanguageCommandQuery.Commands.DeleteLanguage;
using CodeApp.Application.Features.LanguageCommandQuery.Commands.UpdateLanguage;
using CodeApp.Application.Features.LanguageCommandQuery.Queries.GetAllLanguage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LanguagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LanguagesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetAll()
    => Ok(await _mediator.Send(new GetAllLanguageQueryRequest()));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateLanguageCommandRequest request)
    {
        var response = await _mediator.Send(request);

        return StatusCode(201, response);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(UpdateLanguageCommandRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteLanguageCommandRequest(id));

        return NoContent();
    }
}
