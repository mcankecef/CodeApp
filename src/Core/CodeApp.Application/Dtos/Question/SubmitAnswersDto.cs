namespace CodeApp.Application.Dtos.Question;

public class SubmitAnswerDto
{
    public Guid QuestionId { get; set; }
    public string UserAnswer { get; set; } = string.Empty;
}

public class SubmitAnswersRequestDto
{
    public Guid AppUserId { get; set; }
    public Guid StepQuestionId { get; set; }
    public Guid LanguageId { get; set; }
    public List<SubmitAnswerDto> Answers { get; set; } = new();
}

public class SubmitAnswersResponseDto
{
    public int TotalScore { get; set; }
    public int CorrectAnswers { get; set; }
    public int TotalQuestions { get; set; }
    public bool StepCompleted { get; set; }
    public int NewStepNumber { get; set; }
    public string Message { get; set; } = string.Empty;
}