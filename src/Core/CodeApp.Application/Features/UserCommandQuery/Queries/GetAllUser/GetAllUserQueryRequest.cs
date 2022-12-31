using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetAllUser
{
    public class GetAllUserQueryRequest : IRequest<BaseResponse<List<GetAllUserDto>>>
    {
    }
}
