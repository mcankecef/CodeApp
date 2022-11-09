using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion
{
    public class GetAllQuestionQueryRequest : IRequest<BaseResponse<List<GetAllQuestionDto>>>
    {
    }
}
