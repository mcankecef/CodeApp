using CodeApp.Domain.Enums;

namespace CodeApp.Application.Dtos.Question
{
    public class GetQuestionByIdDto
    {
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public QuestionLevel Level { get; set; }
        public string LanguageName { get; set; }
    }
}
