using System.ComponentModel.DataAnnotations;

namespace CodeApp.Domain.Enums
{
    public enum UserRoles
    {
        [Display(Name = "Üye")]
        Member = 1,
        [Display(Name = "Admin")]
        Admin
    }
}
