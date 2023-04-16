using Microsoft.AspNetCore.Identity;

namespace CodeApp.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public int Score { get; set; }
        public Guid? AvatarId { get; set; }
        public Avatar Avatar { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
