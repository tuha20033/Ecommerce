
using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<List<Product>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
        Task<(List<Product> , int total)> GetPageAsync(int pageNumber, int pageSize,string? keyword, CancellationToken cancellationToken);
        Task<List<Product>> GetActiveAsync(CancellationToken cancellationToken);
        Task<Product?> GetByCodeAsync(string productCode, CancellationToken cancellationToken);
        Task<Product?> GetWithInventoryAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Product>> GetAllWithDetailsAsync(CancellationToken cancellationToken);
    }
}
