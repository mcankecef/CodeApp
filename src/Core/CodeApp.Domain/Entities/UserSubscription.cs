using CodeApp.Domain.Entities.Identity;
using CodeApp.Domain.Enums;

namespace CodeApp.Domain.Entities.Subscription;

public class UserSubscription : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public AppUser User { get; set; } = null!;
    public SubscriptionProvider Provider { get; set; }
    public SubscriptionTier Tier { get; set; } = SubscriptionTier.Standard;
    public SubscriptionStatus Status { get; set; } = SubscriptionStatus.None;
    public string ProductId { get; set; } = string.Empty;
    public string OriginalTransactionId { get; set; } = string.Empty;
    public string? TransactionId { get; set; }
    public DateTime PurchaseDateUtc { get; set; }
    public DateTime? ExpiresDateUtc { get; set; }
    public DateTime? LastVerifiedUtc { get; set; }
    public string? RawPayload { get; set; }
}
