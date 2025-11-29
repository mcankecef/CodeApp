namespace CodeApp.Application.Dtos.Admin
{
    public class DailyStatsDto
    {
        public int NewUsersToday { get; set; }
        public int QuestionsAnsweredToday { get; set; }
        public int ActiveUsersToday { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
    }
}