using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion
{
    public class GetAllQuestionQueryRequest : IRequest<BaseResponse<List<GetAllQuestionDto>>>
    {
        public QuestionLevel Level { get; set; }
        public GetAllQuestionQueryRequest(QuestionLevel level)
        {
            Level = level;
        }
    }
}
