namespace CodeApp.Application.Dtos.Token
{
    public class TokenDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int Score { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
    }
}
