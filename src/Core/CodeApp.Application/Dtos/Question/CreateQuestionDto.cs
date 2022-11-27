using CodeApp.Application.Dtos.Answer;
using CodeApp.Domain.Entities;

namespace CodeApp.Application.Dtos.Question
{
    public class CreateQuestionDto
    {
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
        public List<CreateAnswerDto> Answers { get; set; }
    }
}
