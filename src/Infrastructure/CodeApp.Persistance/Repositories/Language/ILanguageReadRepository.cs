using CodeApp.Application.Repositories;
using CodeApp.Domain.Entities;
using CodeApp.Persistance.Contexts;

namespace CodeApp.Persistance.Repositories
{
    public class LanguageReadRepository : ReadRepository<Language> ,ILanguageReadRepository
    {
        public LanguageReadRepository(CodeAppDbContext context) : base(context)
        {
        }
    }
}
