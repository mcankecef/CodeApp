using CodeApp.Domain.Enums;

namespace CodeApp.Application.Dtos.User;
public class GetUserByIdDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Score { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Guid AvatarId { get; set; }
    public bool IsPremium { get; set; }
    public SubscriptionTier SubscriptionTier { get; set; } = SubscriptionTier.Standard;
    public SubscriptionStatus SubscriptionStatus { get; set; } = SubscriptionStatus.None;
    public DateTime? PremiumUntilUtc { get; set; }
}
