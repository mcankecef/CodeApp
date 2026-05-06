using CodeApp.Domain.Entities.Subscription;
using Microsoft.AspNetCore.Identity;

namespace CodeApp.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public int Score { get; set; }
        public Guid? AvatarId { get; set; }
        public Avatar? Avatar { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public UserStreak? Streak { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoggedSession { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<UserSubscription> Subscriptions { get; set; } = new List<UserSubscription>();
    }
}
