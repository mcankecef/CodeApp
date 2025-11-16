namespace CodeApp.Application.Dtos.Streak
{
    public class UserStreakDto
    {
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? StreakStartDate { get; set; }
    }
}