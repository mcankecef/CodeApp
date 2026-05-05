using CodeApp.Application.Dtos.User;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.UserCommandQuery.Queries.GetUserStats;

public class GetUserStatsQueryRequest : IRequest<BaseResponse<UserStatsDto>>
{
}
