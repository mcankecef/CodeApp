using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class AnswerWriteRepository : WriteRepository<Answer> , IAnswerWriteRepository
    {
        public AnswerWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
