using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public UpdateUserCommandRequest(string userId, string fullName, string? email)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
        }
        public string UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public Guid? AvatarId { get; set; }
    }
}
