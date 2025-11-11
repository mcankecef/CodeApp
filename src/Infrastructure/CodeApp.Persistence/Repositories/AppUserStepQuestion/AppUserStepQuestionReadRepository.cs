using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Persistence.Contexts;
using CodeApp.Persistence.Repositories;

namespace CodeApp.Persistence.Repositories.AppUserStepQuestion;

public class AppUserStepQuestionReadRepository : ReadRepository<Domain.Entities.AppUserStepQuestion>, IAppUserStepQuestionReadRepository
{
    public AppUserStepQuestionReadRepository(CodeAppDbContext context) : base(context)
    {
    }
}