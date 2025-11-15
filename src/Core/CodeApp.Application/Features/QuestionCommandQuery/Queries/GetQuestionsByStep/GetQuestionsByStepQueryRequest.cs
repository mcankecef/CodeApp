using CodeApp.Application.Dtos.StepQuestion;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetQuestionsByStep;

public class GetQuestionsByStepQueryRequest : IRequest<BaseResponse<GetStepQuestionsResponseDto>>
{
    public Guid LanguageId { get; set; }
    public string AppUserId { get; set; } = null!;
    public Guid StepQuestionId { get; set; }
}