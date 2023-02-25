using CodeApp.Application.Dtos.Answer;
using CodeApp.Application.Wrapper;
using MediatR;

namespace CodeApp.Application.Features.AnswerCommandQuery.Queries.GetAllAnswer
{
    public class GetAllAnswerQueryRequest : IRequest<BaseResponse<GetAllAnswerDto>>
    {
    }
}
