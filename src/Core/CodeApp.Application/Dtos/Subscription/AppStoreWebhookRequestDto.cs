using CodeApp.Domain.Enums;

namespace CodeApp.Application.Dtos.Subscription;

public class AppStoreWebhookRequestDto
{
    public string OriginalTransactionId { get; set; } = string.Empty;
    public string? TransactionId { get; set; }
    public string? ProductId { get; set; }
    public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;
    public DateTime? ExpiresDateUtc { get; set; }
    public string? EventType { get; set; }
    public string? RawPayload { get; set; }
}
