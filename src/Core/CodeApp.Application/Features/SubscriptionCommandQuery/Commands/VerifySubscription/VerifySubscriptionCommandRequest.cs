using CodeApp.Application.Dtos.Subscription;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubscriptionCommandQuery.Commands.VerifySubscription;

public class VerifySubscriptionCommandRequest : IRequest<BaseResponse<SubscriptionStateDto>>
{
    public string UserId { get; set; } = string.Empty;
    public VerifySubscriptionRequestDto Payload { get; set; } = new();
}
