using CodeApp.Application.Dtos.Admin;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.DashboardCommandQuery.Queries.GetDashboardStats
{
    public class GetDashboardStatsQueryRequest : IRequest<BaseResponse<DashboardStatsDto>>
    {
    }
}