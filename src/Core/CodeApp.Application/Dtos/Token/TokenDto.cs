namespace CodeApp.Application.Dtos.Token
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }
        public string RefreshToken { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
