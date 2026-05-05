using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetQuestionStats;

public class GetQuestionStatsQueryRequest : IRequest<BaseResponse<QuestionStatsDto>>
{
}
