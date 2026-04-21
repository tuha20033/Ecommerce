
namespace Application.Abstractions.Repositories
{
    public  interface  IGenericRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllAsync( CancellationToken ct);
        Task<T?> GetByIdAsync(Guid id, CancellationToken ct);
        Task AddAsync(T entity, CancellationToken ct);
        Task UpdateAsync(T entity, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}
