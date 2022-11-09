using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Wrapper;
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
    }
}
