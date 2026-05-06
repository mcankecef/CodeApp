using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Dtos.Subscription;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.SubscriptionCommandQuery.Commands.VerifySubscription;

public class VerifySubscriptionCommandHandler : IRequestHandler<VerifySubscriptionCommandRequest, BaseResponse<SubscriptionStateDto>>
{
    private readonly ISubscriptionService _subscriptionService;

    public VerifySubscriptionCommandHandler(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    public async Task<BaseResponse<SubscriptionStateDto>> Handle(VerifySubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.UserId))
            return new BaseResponse<SubscriptionStateDto>("Unauthorized user.", false);

        var result = await _subscriptionService.VerifyAsync(request.UserId, request.Payload, cancellationToken);
        return new BaseResponse<SubscriptionStateDto>("Subscription verified.", true, result);
    }
}
