namespace CodeApp.Application.Dtos.StepQuestion;

public class StepQuestionDto
{
    public Guid Id { get; set; }
    public int StepNumber { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsLocked { get; set; }
    public bool IsCurrentStep { get; set; }
}