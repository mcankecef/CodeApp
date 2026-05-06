using CodeApp.Application.Abstractions.Services;
using CodeApp.Application.Dtos.Subscription;
using CodeApp.Application.Repositories.Subscription;
using CodeApp.Domain.Entities.Subscription;
using CodeApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Persistence.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly IUserSubscriptionReadRepository _userSubscriptionReadRepository;
    private readonly IUserSubscriptionWriteRepository _userSubscriptionWriteRepository;

    public SubscriptionService(
        IUserSubscriptionReadRepository userSubscriptionReadRepository,
        IUserSubscriptionWriteRepository userSubscriptionWriteRepository)
    {
        _userSubscriptionReadRepository = userSubscriptionReadRepository;
        _userSubscriptionWriteRepository = userSubscriptionWriteRepository;
    }

    public async Task<SubscriptionStateDto> VerifyAsync(string userId, VerifySubscriptionRequestDto request, CancellationToken cancellationToken)
    {
        var tier = ResolveTier(request.ProductId);
        var status = ResolveStatus(request.ExpiresDateUtc, SubscriptionStatus.Active);

        var subscription = await _userSubscriptionReadRepository.Queryable()
            .FirstOrDefaultAsync(x => x.Provider == request.Provider && x.OriginalTransactionId == request.OriginalTransactionId, cancellationToken);

        if (subscription is null)
        {
            subscription = new UserSubscription
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Provider = request.Provider,
                Tier = tier,
                Status = status,
                ProductId = request.ProductId,
                OriginalTransactionId = request.OriginalTransactionId,
                TransactionId = request.TransactionId,
                PurchaseDateUtc = request.PurchaseDateUtc == default ? DateTime.UtcNow : request.PurchaseDateUtc,
                ExpiresDateUtc = request.ExpiresDateUtc,
                LastVerifiedUtc = DateTime.UtcNow,
                RawPayload = request.ReceiptData
            };

            await _userSubscriptionWriteRepository.CreateAsync(subscription);
            return BuildStateDto(subscription);
        }
        else
        {
            subscription.UserId = userId;
            subscription.ProductId = request.ProductId;
            subscription.TransactionId = request.TransactionId;
            subscription.Tier = tier;
            subscription.Status = status;
            subscription.ExpiresDateUtc = request.ExpiresDateUtc;
            subscription.LastVerifiedUtc = DateTime.UtcNow;
            subscription.RawPayload = request.ReceiptData;
            subscription.UpdatedDate = DateTime.UtcNow;
        }

        await _userSubscriptionWriteRepository.SaveAsync();

        return BuildStateDto(subscription);
    }

    public async Task HandleAppStoreWebhookAsync(AppStoreWebhookRequestDto request, CancellationToken cancellationToken)
    {
        var subscription = await _userSubscriptionReadRepository.Queryable()
            .FirstOrDefaultAsync(
                x => x.Provider == SubscriptionProvider.AppStore && x.OriginalTransactionId == request.OriginalTransactionId,
                cancellationToken);

        if (subscription is null)
            return;

        subscription.TransactionId = request.TransactionId ?? subscription.TransactionId;
        subscription.ProductId = request.ProductId ?? subscription.ProductId;
        subscription.Status = ResolveStatus(request.ExpiresDateUtc ?? subscription.ExpiresDateUtc, request.Status);
        subscription.ExpiresDateUtc = request.ExpiresDateUtc ?? subscription.ExpiresDateUtc;
        subscription.LastVerifiedUtc = DateTime.UtcNow;
        subscription.RawPayload = request.RawPayload ?? request.EventType ?? subscription.RawPayload;
        subscription.UpdatedDate = DateTime.UtcNow;

        _userSubscriptionWriteRepository.Update(subscription);
    }

    private static SubscriptionTier ResolveTier(string productId)
    {
        var normalized = productId.Trim().ToLowerInvariant();
        if (normalized.Contains("super"))
            return SubscriptionTier.SuperPremium;
        if (normalized.Contains("premium"))
            return SubscriptionTier.Premium;
        return SubscriptionTier.Standard;
    }

    private static SubscriptionStatus ResolveStatus(DateTime? expiresAtUtc, SubscriptionStatus currentStatus)
    {
        if (currentStatus is SubscriptionStatus.Canceled or SubscriptionStatus.Refunded)
            return currentStatus;

        if (expiresAtUtc.HasValue && expiresAtUtc.Value <= DateTime.UtcNow)
            return SubscriptionStatus.Expired;

        return SubscriptionStatus.Active;
    }

    private static SubscriptionStateDto BuildStateDto(UserSubscription subscription)
    {
        var active = subscription.Status == SubscriptionStatus.Active || subscription.Status == SubscriptionStatus.InGracePeriod;
        return new SubscriptionStateDto
        {
            Tier = active ? subscription.Tier : SubscriptionTier.Standard,
            Status = subscription.Status,
            ExpiresDateUtc = subscription.ExpiresDateUtc,
            IsActive = active,
            ProductId = subscription.ProductId,
            OriginalTransactionId = subscription.OriginalTransactionId
        };
    }
}
