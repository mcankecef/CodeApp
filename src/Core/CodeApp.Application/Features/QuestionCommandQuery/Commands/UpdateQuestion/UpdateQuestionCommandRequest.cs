using CodeApp.Application.Dtos;
using CodeApp.Application.Wrapper;
using CodeApp.Domain.Enums;
using MediatR;

namespace CodeApp.Application.Features.QuestionCommandQuery.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandRequest : IRequest<BaseResponse<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
        public QuestionLevel Level { get; set; }
    }
}
