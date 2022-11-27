namespace CodeApp.Application.Dtos.Answer
{
    public class CreateAnswerDto
    {
        public Guid QuestionId { get; set; }
        public List<string> AnswerName { get; set; }
    }
}
