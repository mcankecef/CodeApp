using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class SubjectReadRepository : ReadRepository<Subject>, ISubjectReadRepository
    {
        public SubjectReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
