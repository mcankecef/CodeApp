using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public Guid Id { get; set; }

        public DeleteQuestionCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
