namespace CodeApp.Application.Dtos.Auth
{
    public class GoogleUserInfoDto
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Sub { get; set; } = string.Empty; // Google User ID
    }
}
