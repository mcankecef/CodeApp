using CodeApp.Application.Repositories;
using CodeApp.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeApp.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, new()
    {
        private readonly CodeAppDbContext _context;

        public ReadRepository(CodeAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter) => await _context.Set<T>()
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(filter);

        public async Task<T> GetByIdAsync(object id) => await _context.Set<T>().FindAsync(id);

        public IQueryable<T> Queryable() => _context.Set<T>().AsQueryable();
    }
}
