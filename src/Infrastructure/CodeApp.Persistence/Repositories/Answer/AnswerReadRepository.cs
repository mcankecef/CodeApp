using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CodeApp.Persistence.Repositories
{
    public class AnswerReadRepository : ReadRepository<Answer>, IAnswerReadRepository
    {
        public AnswerReadRepository(CodeAppDbContext context) : base(context)
        {
        }

        public async Task<List<Answer>> GetAllByQuestionIdAsync(Guid questionId)
        {
            return await
                 Queryable()
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }
    }
}
