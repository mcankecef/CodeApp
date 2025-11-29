using CodeApp.Domain.Enums;

namespace CodeApp.Domain.Entities
{
    public class Language : BaseEntity
    {
        public Language()
        {
            Questions = new List<Question>();
            Subjects = new List<Subject>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public StatusType Status { get; set; }
    }
}
