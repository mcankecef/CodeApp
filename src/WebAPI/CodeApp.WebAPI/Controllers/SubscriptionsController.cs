using CodeApp.Application.Dtos.Subscription;
using CodeApp.Application.Features.SubscriptionCommandQuery.Commands.HandleAppStoreWebhook;
using CodeApp.Application.Features.SubscriptionCommandQuery.Commands.VerifySubscription;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("verify")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> Verify([FromBody] VerifySubscriptionRequestDto request, CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var response = await _mediator.Send(new VerifySubscriptionCommandRequest
        {
            UserId = userId,
            Payload = request
        }, cancellationToken);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("webhook/appstore")]
    [AllowAnonymous]
    public async Task<IActionResult> AppStoreWebhook(
        [FromBody] AppStoreWebhookRequestDto request,
        [FromHeader(Name = "X-Webhook-Secret")] string? webhookSecret,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new HandleAppStoreWebhookCommandRequest
        {
            WebhookSecret = webhookSecret,
            Payload = request
        }, cancellationToken);

        if (!response.IsSuccess)
            return Unauthorized();

        return Ok(new { ok = true });
    }
}
