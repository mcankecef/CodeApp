using CodeApp.Domain.Enums;

namespace CodeApp.WebAPI.Models
{
    public class GetAllQuestionRequestModel
    {
        public Guid LanguageId { get; set; }
        public int QuestionLevel { get; set; }
    }
}
