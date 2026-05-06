namespace CodeApp.Domain.Enums;

public enum SubscriptionStatus
{
    None = 0,
    Active = 1,
    Expired = 2,
    Canceled = 3,
    InGracePeriod = 4,
    Refunded = 5
}
