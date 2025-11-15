using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.StepQuestionCommandQuery.Queries.GetStepQuestions;

public class GetStepQuestionsQueryRequest : IRequest<BaseResponse<List<StepQuestionDto>>>
{
    public Guid LanguageId { get; set; }
    public string AppUserId { get; set; } = null!;
}