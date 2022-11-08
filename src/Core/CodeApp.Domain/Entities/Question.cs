namespace CodeApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }

        // A question must has one language
        public Language Language { get; set; }

        // A question has more than one answer
        public ICollection<Answer> Answers { get; set; }
    }
}
