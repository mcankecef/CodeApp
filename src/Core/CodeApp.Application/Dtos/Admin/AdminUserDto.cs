namespace CodeApp.Application.Dtos.Admin
{
    public class AdminUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public int TotalScore { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public List<string> Roles { get; set; } = new();
        public UserStreakInfoDto? Streak { get; set; }
        public int CompletedQuestions { get; set; }
        public string? AvatarName { get; set; }
    }
}