using CodeApp.Domain.Enums;

namespace CodeApp.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }

        public Language Language { get; set; }
        public StatusType Status { get; set; }

    }
}
