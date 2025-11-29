namespace CodeApp.Application.Dtos.User
{
    public class LoginUserDto
    {
        public required string UsernameOrEmail { get; set; }
        public required string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
