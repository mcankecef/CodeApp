namespace CodeApp.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, new()
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> CreateRangeAsync(IEnumerable<T> entities);
        bool Update(T entity);
        bool UpdateRange(IEnumerable<T> entities);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        Task<int> SaveAsync();
    }
}
