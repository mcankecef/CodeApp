namespace CodeApp.Application.Dtos.Admin
{
    public class DashboardStatsDto
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalLanguages { get; set; }
        public int TotalAnswers { get; set; }
        public int PendingQuestions { get; set; }
        public DailyStatsDto DailyStats { get; set; } = new();
        public List<LanguageStatsDto> LanguageStats { get; set; } = new();
        public List<UserActivityDto> RecentUserActivities { get; set; } = new();
    }
}