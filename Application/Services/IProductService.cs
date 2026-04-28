

using Domain.Entities;

namespace Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetActiveProductsAsync(CancellationToken cancellationToken);
    }
}
