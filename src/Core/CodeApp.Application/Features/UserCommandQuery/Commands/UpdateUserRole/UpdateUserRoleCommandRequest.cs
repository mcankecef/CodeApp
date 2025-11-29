using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public string UserId { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();
    }
}