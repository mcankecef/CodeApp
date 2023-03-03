using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class QuestionReadRepository : ReadRepository<Question>, IQuestionReadRepository
    {
        public QuestionReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
