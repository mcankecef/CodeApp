using CodeApp.Application.Dtos.Answer;
using CodeApp.Domain.Entities;
using CodeApp.Domain.Enums;

namespace CodeApp.Application.Dtos.Question
{
    public class CreateQuestionDto
    {
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public QuestionLevel Level { get; set; }
        public Guid LanguageId { get; set; }
        public List<CreateAnswerDto> Answers { get; set; }
    }
}
