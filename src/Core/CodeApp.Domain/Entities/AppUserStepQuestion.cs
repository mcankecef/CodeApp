using CodeApp.Domain.Entities.Identity;

namespace CodeApp.Domain.Entities;

public class AppUserStepQuestion : BaseEntity
{
    public string AppUserId { get; set; } = null!;
    public Guid LanguageId { get; set; }
    public Guid StepQuestionId { get; set; }
    public int CurrentStepNumber { get; set; } = 1;
    public int Score { get; set; } = 0;

    public AppUser AppUser { get; set; } = null!;
    public StepQuestion StepQuestion { get; set; } = null!;
}