using CodeApp.Domain.Entities.Identity;

namespace CodeApp.Domain.Entities
{
    public class UserStreak : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public int CurrentStreak { get; set; } = 0;
        public int LongestStreak { get; set; } = 0;
        public DateTime? LastActivityDate { get; set; }
        public DateTime? StreakStartDate { get; set; }
        
        // Navigation Properties
        public AppUser User { get; set; } = null!;
    }
}