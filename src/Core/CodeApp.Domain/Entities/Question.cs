namespace CodeApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Name { get; set; }
        public string Answer { get; set; }
        public int Score { get; set; }

        // A question must has one language
        public Language Language { get; set; }
    }
}
