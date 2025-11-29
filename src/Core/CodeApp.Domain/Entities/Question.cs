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

        public Language Language { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public StatusType Status { get; set; }
        
        public Guid? StepQuestionId { get; set; } 
        public StepQuestion? StepQuestion { get; set; }
    }
}
