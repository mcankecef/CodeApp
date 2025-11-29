using CodeApp.Application.Features.AvatarCommandQuery.Commands.CreateAvatar;
using CodeApp.Application.Features.AvatarCommandQuery.Queries.GetAllAvatar;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AvatarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AvatarsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllAvatarQueryRequest()));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateAvatarCommandRequest request)
    {
        var avatar = await _mediator.Send(request);

        return StatusCode(201, avatar);
    }
}
