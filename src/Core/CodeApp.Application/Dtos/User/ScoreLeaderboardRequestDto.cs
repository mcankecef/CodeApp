namespace CodeApp.Application.Dtos.User
{
    public class ScoreLeaderboardRequestDto
    {
        public Guid LanguageId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}