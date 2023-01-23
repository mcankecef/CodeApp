using CodeApp.Application.Dtos.Answer;
using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion
{
    public class CreateQuestionCommandRequest : IRequest<BaseResponse<CreateQuestionDto>>
    {
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
        public QuestionLevel Level { get; set; }
        //public List<CreateAnswerDto>? Answer { get; set; }
    }
}
