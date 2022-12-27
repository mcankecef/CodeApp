using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Application.Dtos.User
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
