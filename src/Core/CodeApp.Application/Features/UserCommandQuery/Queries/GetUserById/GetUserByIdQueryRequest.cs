using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetByUserId
{
    public class GetUserByIdQueryRequest : IRequest<BaseResponse<GetUserByIdDto>>
    {
        public string UserId { get; set; }

        public GetUserByIdQueryRequest(string userId)
        {
            UserId = userId;
        }
    }
}
