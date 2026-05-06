using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CodeApp.Application.Features.SubscriptionCommandQuery.Commands.HandleAppStoreWebhook;

public class HandleAppStoreWebhookCommandHandler : IRequestHandler<HandleAppStoreWebhookCommandRequest, BaseResponse<bool>>
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IConfiguration _configuration;

    public HandleAppStoreWebhookCommandHandler(ISubscriptionService subscriptionService, IConfiguration configuration)
    {
        _subscriptionService = subscriptionService;
        _configuration = configuration;
    }

    public async Task<BaseResponse<bool>> Handle(HandleAppStoreWebhookCommandRequest request, CancellationToken cancellationToken)
    {
        var configuredSecret = _configuration["AppStore:WebhookSecret"];
        if (!string.IsNullOrWhiteSpace(configuredSecret) &&
            !string.Equals(request.WebhookSecret, configuredSecret, StringComparison.Ordinal))
        {
            return new BaseResponse<bool>("Unauthorized webhook.", false, false);
        }

        await _subscriptionService.HandleAppStoreWebhookAsync(request.Payload, cancellationToken);
        return new BaseResponse<bool>(true, true);
    }
}
