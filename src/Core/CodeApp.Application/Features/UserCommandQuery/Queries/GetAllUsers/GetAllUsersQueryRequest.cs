using CodeApp.Application.Dtos.Admin;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<BaseResponse<List<AdminUserDto>>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? SearchTerm { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
    }
}