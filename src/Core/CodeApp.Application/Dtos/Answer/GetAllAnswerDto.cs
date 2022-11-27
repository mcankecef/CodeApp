using CodeApp.Application.Dtos.Question;

namespace CodeApp.Application.Dtos.Answer
{
    public class GetAllAnswerDto
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string QuestionName { get; set; }
        public List<string> Answer { get; set; }
    }
}
