using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AnswerCommandQuery.Commands.DeleteAnswer
{
    public class DeleteAnswerCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public Guid QuestionId { get; set; }

        public DeleteAnswerCommandRequest(Guid questionId)
        {
            QuestionId = questionId;
        }
    }
}
