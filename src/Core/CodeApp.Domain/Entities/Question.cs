using CodeApp.Domain.Enums;

namespace CodeApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        public Question()
        {
            Answers = new List<Answer>();
        }
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
        public QuestionLevel Level { get; set; }

        // A question must has one language
        public Language Language { get; set; }

        // A question has more than one answer
        public ICollection<Answer> Answers { get; set; }
        public StatusType Status { get; set; }
    }
}
