namespace CodeApp.Application.Dtos.Admin
{
    public class LanguageStatsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuestionCount { get; set; }
        public int UserCount { get; set; }
        public int CompletedQuestions { get; set; }
        public double AverageScore { get; set; }
    }
}