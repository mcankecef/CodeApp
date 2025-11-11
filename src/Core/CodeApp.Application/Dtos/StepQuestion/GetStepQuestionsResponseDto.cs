using CodeApp.Application.Dtos.Question;

namespace CodeApp.Application.Dtos.StepQuestion;

public class GetStepQuestionsResponseDto
{
    public Guid StepId { get; set; }
    public string StepTitle { get; set; } = string.Empty;
    public int StepNumber { get; set; }
    public List<QuestionDto> Questions { get; set; } = new();
}