using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.StepQuestionCommandQuery.Queries.GetAllStepQuestions;

public class GetAllStepQuestionsQueryRequest : IRequest<BaseResponse<List<StepQuestionDto>>>
{
    public Guid LanguageId { get; set; }
}
