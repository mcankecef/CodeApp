using CodeApp.Application.Dtos.Answer;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.AnswerCommandQuery.Commands.CreateAnswer
{
    public class CreateAnswerCommandRequest : IRequest<BaseResponse<CreateAnswerDto>>
    {
        public Guid QuestionId { get; set; }
        public List<string> AnswerName { get; set; }
        public StatusType Status { get; set; }
    }
}
