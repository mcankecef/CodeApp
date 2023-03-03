using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class QuestionWriteRepository : WriteRepository<Question>, IQuestionWriteRepository
    {
        public QuestionWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
