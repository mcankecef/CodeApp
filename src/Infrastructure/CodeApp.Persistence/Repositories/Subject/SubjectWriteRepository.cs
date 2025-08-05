using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    public class SubjectWriteRepository : WriteRepository<Subject>, ISubjectWriteRepository
    {
        public SubjectWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
