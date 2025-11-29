namespace CodeApp.Application.Dtos.Auth
{
    public class GoogleLoginDto
    {
        public string IdToken { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = false;
    }
}
