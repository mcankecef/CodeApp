namespace CodeApp.Application.Dtos.User
{
    public class ScoreLeaderboardResponseDto
    {
        public List<UserScoreRankDto> Users { get; set; } = new();
        public int CurrentUserRank { get; set; }
        public int TotalUsers { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}