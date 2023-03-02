namespace CodeApp.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }

        // A question must has one language
        public Language Language { get; set; }
    }
}
