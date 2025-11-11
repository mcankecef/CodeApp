using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories.StepQuestion
{
    public class StepQuestionWriteRepository : WriteRepository<Domain.Entities.StepQuestion>, IStepQuestionWriteRepository
    {
        public StepQuestionWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}