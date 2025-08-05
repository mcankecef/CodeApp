using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    public class AnswerWriteRepository : WriteRepository<Answer> , IAnswerWriteRepository
    {
        public AnswerWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
