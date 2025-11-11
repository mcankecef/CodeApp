namespace CodeApp.Application.Dtos.Question;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Level { get; set; }
    public int Score { get; set; }
    public string CorrectAnswer { get; set; } = string.Empty;
    public List<string> Answers { get; set; } = new();
}