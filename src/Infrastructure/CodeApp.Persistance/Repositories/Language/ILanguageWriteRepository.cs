using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class LanguageWriteRepository : WriteRepository<Language>, ILanguageWriteRepository
    {
        public LanguageWriteRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
