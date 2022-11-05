namespace CodeApp.Domain.Entities
{
    public class Language : BaseEntity
    {
        public Language()
        {
            Questions = new List<Question>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        // A language has more than one question
        public ICollection<Question> Questions { get; set; }

    }
}
