using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.StepQuestionCommandQuery.Commands.CreateStepQuestion;

public class CreateStepQuestionCommandRequest : IRequest<BaseResponse<Guid>>
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid LanguageId { get; set; }
    public int StepNumber { get; set; }
    public StatusType Status { get; set; } = StatusType.Active;
}
