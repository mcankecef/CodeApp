using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AppUserStepQuestionCommandQuery.Queries.GetUserStepQuestions;

public class GetUserStepQuestionsQueryRequest : IRequest<BaseResponse<List<StepQuestionDto>>>
{
    public Guid LanguageId { get; set; }
    public string AppUserId { get; set; } = null!;
}
