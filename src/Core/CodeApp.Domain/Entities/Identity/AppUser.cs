using Microsoft.AspNetCore.Identity;

namespace CodeApp.Domain.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
