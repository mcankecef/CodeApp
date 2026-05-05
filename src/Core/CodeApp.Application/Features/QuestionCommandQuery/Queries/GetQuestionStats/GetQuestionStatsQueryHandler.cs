using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetQuestionStats;

public class GetQuestionStatsQueryHandler : IRequestHandler<GetQuestionStatsQueryRequest, BaseResponse<QuestionStatsDto>>
{
    private readonly IQuestionReadRepository _questionReadRepository;

    public GetQuestionStatsQueryHandler(IQuestionReadRepository questionReadRepository)
    {
        _questionReadRepository = questionReadRepository;
    }

    public async Task<BaseResponse<QuestionStatsDto>> Handle(GetQuestionStatsQueryRequest request, CancellationToken cancellationToken)
    {
        var questions = await _questionReadRepository.GetAllAsync();

        var stats = new QuestionStatsDto
        {
            TotalQuestions = questions.Count,
            ActiveQuestions = questions.Count(q => q.Status == StatusType.Active),
            PendingQuestions = questions.Count(q => q.Status == StatusType.Passive)
        };

        return new BaseResponse<QuestionStatsDto>("Question statistics retrieved successfully", true, stats);
    }
}
