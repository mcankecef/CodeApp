using CodeApp.Application.Dtos.Avatar;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AvatarCommandQuery.Queries.GetAllAvatar
{
    public class GetAllAvatarQueryRequest : IRequest<BaseResponse<List<GetAllAvatarDto>>>
    {
    }
}
