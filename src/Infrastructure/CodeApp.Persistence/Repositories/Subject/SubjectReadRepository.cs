using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    public class SubjectReadRepository : ReadRepository<Subject>, ISubjectReadRepository
    {
        public SubjectReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
