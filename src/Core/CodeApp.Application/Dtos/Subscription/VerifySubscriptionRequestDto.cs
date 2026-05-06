using CodeApp.Domain.Enums;

namespace CodeApp.Application.Dtos.Subscription;

public class VerifySubscriptionRequestDto
{
    public SubscriptionProvider Provider { get; set; } = SubscriptionProvider.AppStore;
    public string ProductId { get; set; } = string.Empty;
    public string OriginalTransactionId { get; set; } = string.Empty;
    public string? TransactionId { get; set; }
    public DateTime PurchaseDateUtc { get; set; }
    public DateTime? ExpiresDateUtc { get; set; }
    public string? ReceiptData { get; set; }
    public bool IsSandbox { get; set; }
}
