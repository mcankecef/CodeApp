using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class AnswerReadRepository : ReadRepository<Answer> , IAnswerReadRepository
    {
        public AnswerReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
