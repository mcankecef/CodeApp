using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Dtos.Subscription;
using CodeApp.Application.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IConfiguration _configuration;

    public SubscriptionsController(ISubscriptionService subscriptionService, IConfiguration configuration)
    {
        _subscriptionService = subscriptionService;
        _configuration = configuration;
    }

    [HttpPost("verify")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> Verify([FromBody] VerifySubscriptionRequestDto request, CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _subscriptionService.VerifyAsync(userId, request, cancellationToken);
        return Ok(new BaseResponse<SubscriptionStateDto>("Subscription verified.", true, result));
    }

    [HttpGet("me")]
    [Authorize(Roles = "Admin,Member")]
    public async Task<IActionResult> Me(CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _subscriptionService.GetMySubscriptionAsync(userId, cancellationToken);
        return Ok(new BaseResponse<SubscriptionStateDto>(result, true));
    }

    [HttpPost("webhook/appstore")]
    [AllowAnonymous]
    public async Task<IActionResult> AppStoreWebhook(
        [FromBody] AppStoreWebhookRequestDto request,
        [FromHeader(Name = "X-Webhook-Secret")] string? webhookSecret,
        CancellationToken cancellationToken)
    {
        var configuredSecret = _configuration["AppStore:WebhookSecret"];
        if (!string.IsNullOrWhiteSpace(configuredSecret) && !string.Equals(webhookSecret, configuredSecret, StringComparison.Ordinal))
            return Unauthorized();

        await _subscriptionService.HandleAppStoreWebhookAsync(request, cancellationToken);
        return Ok(new { ok = true });
    }
}
