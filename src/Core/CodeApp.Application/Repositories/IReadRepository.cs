using CodeApp.Domain.Enums;
using System.Linq.Expressions;

namespace CodeApp.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> Queryable();
        Task<List<T>> GetAllByStatusAsync(StatusType statusType);
    }
}
