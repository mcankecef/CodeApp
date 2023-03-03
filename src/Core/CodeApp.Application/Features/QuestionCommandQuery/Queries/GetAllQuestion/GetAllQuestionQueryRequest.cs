using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion
{
    public class GetAllQuestionQueryRequest : IRequest<BaseResponse<List<GetAllQuestionDto>>>
    {
        public int QuestionLevel { get; set; }
        public Guid LanguageId { get; set; }
        public GetAllQuestionQueryRequest(int questionLevel, Guid languageId)
        {
            QuestionLevel = questionLevel;
            LanguageId = languageId;
        }
    }
}
