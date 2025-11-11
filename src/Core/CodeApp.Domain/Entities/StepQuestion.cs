using CodeApp.Domain.Enums;

namespace CodeApp.Domain.Entities;
public class StepQuestion : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public Guid LanguageId { get; set; }
    public int StepNumber { get; set; }
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public StatusType Status { get; set; }
}