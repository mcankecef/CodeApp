using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.SubmitAnswers;

public class SubmitAnswersCommandRequest : IRequest<BaseResponse<SubmitAnswersResponseDto>>
{
    public Guid AppUserId { get; set; }
    public Guid StepQuestionId { get; set; }
    public Guid LanguageId { get; set; }
    public List<SubmitAnswerDto> Answers { get; set; } = new();
}