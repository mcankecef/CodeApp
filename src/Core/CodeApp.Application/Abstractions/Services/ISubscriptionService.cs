using CodeApp.Application.Dtos.Subscription;

namespace CodeApp.Application.Abstractions.Services;

public interface ISubscriptionService
{
    Task<SubscriptionStateDto> VerifyAsync(string userId, VerifySubscriptionRequestDto request, CancellationToken cancellationToken);
    Task<SubscriptionStateDto> GetMySubscriptionAsync(string userId, CancellationToken cancellationToken);
    Task HandleAppStoreWebhookAsync(AppStoreWebhookRequestDto request, CancellationToken cancellationToken);
}
