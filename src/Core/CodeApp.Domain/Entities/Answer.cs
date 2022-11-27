namespace CodeApp.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string AnswerName { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
