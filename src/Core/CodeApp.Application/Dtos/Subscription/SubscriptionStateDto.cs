using CodeApp.Domain.Enums;

namespace CodeApp.Application.Dtos.Subscription;

public class SubscriptionStateDto
{
    public SubscriptionTier Tier { get; set; } = SubscriptionTier.Standard;
    public SubscriptionStatus Status { get; set; } = SubscriptionStatus.None;
    public DateTime? ExpiresDateUtc { get; set; }
    public bool IsActive { get; set; }
    public string? ProductId { get; set; }
    public string? OriginalTransactionId { get; set; }
}
