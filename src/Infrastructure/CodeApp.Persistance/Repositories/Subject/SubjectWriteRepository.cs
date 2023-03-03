using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class SubjectWriteRepository : WriteRepository<Subject>, ISubjectWriteRepository
    {
        public SubjectWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
