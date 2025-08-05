using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    public class LanguageWriteRepository : WriteRepository<Language>, ILanguageWriteRepository
    {
        public LanguageWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
