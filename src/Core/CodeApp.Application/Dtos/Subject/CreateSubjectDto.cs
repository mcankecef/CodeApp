namespace CodeApp.Application.Dtos.Subject
{
    public class CreateSubjectDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
    }
}
