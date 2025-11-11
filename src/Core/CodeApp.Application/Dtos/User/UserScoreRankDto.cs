namespace CodeApp.Application.Dtos.User
{
    public class UserScoreRankDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int TotalScore { get; set; }
        public int Rank { get; set; }
        public int CurrentStepNumber { get; set; }
    }
}