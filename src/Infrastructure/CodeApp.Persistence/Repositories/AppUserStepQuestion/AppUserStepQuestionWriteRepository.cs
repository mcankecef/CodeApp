using CodeApp.Application.Repositories.AppUserStepQuestion;
using CodeApp.Persistence.Contexts;
using CodeApp.Persistence.Repositories;

namespace CodeApp.Persistence.Repositories.AppUserStepQuestion;

public class AppUserStepQuestionWriteRepository : WriteRepository<Domain.Entities.AppUserStepQuestion>, IAppUserStepQuestionWriteRepository
{
    public AppUserStepQuestionWriteRepository(CodeAppDbContext context) : base(context)
    {
    }
}