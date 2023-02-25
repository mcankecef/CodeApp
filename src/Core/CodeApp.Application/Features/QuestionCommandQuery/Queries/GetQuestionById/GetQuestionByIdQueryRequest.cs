using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetByIdQuestion
{
    public class GetQuestionByIdQueryRequest : IRequest<BaseResponse<GetQuestionByIdDto>>
    {
        public Guid Id { get; set; }

        public GetQuestionByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
