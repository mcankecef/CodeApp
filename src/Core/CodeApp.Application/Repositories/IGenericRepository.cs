using System.Linq.Expressions;

namespace CodeApp.Application.Repositories
{
    public interface IGenericRepository<T> where T : class, new()
    {
        IQueryable<T> Queryable();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task CreateRange(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
