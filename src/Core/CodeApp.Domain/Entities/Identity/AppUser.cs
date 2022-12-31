using Microsoft.AspNetCore.Identity;

namespace CodeApp.Domain.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public int Score { get; set; }
    }
}
