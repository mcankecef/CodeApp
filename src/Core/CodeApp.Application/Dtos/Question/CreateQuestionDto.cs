namespace CodeApp.Application.Dtos.Question
{
    public class CreateQuestionDto
    {
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
    }
}
