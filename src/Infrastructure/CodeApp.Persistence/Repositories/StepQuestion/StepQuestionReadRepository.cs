using CodeApp.Application.Repositories.StepQuestion;
using CodeApp.Persistence.Contexts;
using CodeApp.Persistence.Repositories;

namespace CodeApp.Persistence.Repositories.StepQuestion;

public class StepQuestionReadRepository : ReadRepository<Domain.Entities.StepQuestion>, IStepQuestionReadRepository
{
    public StepQuestionReadRepository(CodeAppDbContext context) : base(context)
    {
    }
}