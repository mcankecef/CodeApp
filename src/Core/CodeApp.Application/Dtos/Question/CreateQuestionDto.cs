using CodeApp.Application.Dtos.Answer;
using CodeApp.Domain.Entities;
using CodeApp.Domain.Enums;

namespace CodeApp.Application.Dtos.Question
{
    public class CreateQuestionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public int Score { get; set; }
        public string Description { get; set; } = string.Empty; 
        public QuestionLevel Level { get; set; }
        public Guid LanguageId { get; set; }
        public List<string>? Answers { get; set; }
        public Guid? StepQuestionId { get; set; }
    }
}
