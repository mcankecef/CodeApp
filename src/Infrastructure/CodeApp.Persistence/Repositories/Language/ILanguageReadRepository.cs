using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    public class LanguageReadRepository : ReadRepository<Language> ,ILanguageReadRepository
    {
        public LanguageReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
