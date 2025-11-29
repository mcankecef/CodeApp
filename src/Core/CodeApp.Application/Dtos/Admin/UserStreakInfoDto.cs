namespace CodeApp.Application.Dtos.Admin
{
    public class UserStreakInfoDto
    {
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? StreakStartDate { get; set; }
    }
}