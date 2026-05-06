using CodeApp.Application.Dtos.Subscription;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubscriptionCommandQuery.Commands.HandleAppStoreWebhook;

public class HandleAppStoreWebhookCommandRequest : IRequest<BaseResponse<bool>>
{
    public string? WebhookSecret { get; set; }
    public AppStoreWebhookRequestDto Payload { get; set; } = new();
}
