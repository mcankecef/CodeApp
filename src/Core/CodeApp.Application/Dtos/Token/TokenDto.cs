namespace CodeApp.Application.Dtos.Token
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
