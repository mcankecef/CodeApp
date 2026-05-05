using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AnswerCommandQuery.Commands.UpdateAnswer
{
    public class UpdateAnswerCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string AnswerName { get; set; }
        public Guid QuestionId { get; set; }
    }
}
