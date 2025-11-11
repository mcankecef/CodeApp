using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetUserScore
{
    public class GetAllUserScoreQueryRequest : IRequest<BaseResponse<int>>
    {
        public string UserId { get; set; }

        public GetAllUserScoreQueryRequest(string userId)
        {
            UserId = userId;
        }
    }
}
