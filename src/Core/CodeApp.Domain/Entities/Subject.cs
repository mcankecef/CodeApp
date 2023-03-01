using CodeApp.Domain.Enums;

namespace CodeApp.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public SubjectStatus Status { get; set; }
    }
}
