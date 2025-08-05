using CodeApp.Application.Repositories;
using CodeApp.Persistence.Contexts;

namespace CodeApp.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, new()
    {
        private readonly CodeAppDbContext _context;

        public WriteRepository(CodeAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CreateRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
            _context.SaveChanges();
            return true;
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return true;
        }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            _context.SaveChanges();
            return true;
        }
    }
}
