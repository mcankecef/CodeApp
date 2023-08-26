using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.CreateUser
{
    public class CreateUserCommandRequest: IRequest<BaseResponse<CreateUserDto>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public Guid AvatarId { get; set; }
    }
}
