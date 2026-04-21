

using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface IOrderRepository : IGenericRepository<Domain.Entities.Order>
    {
        Task<Order?> GetDetailAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Order>> GetByCustomerIdAsync (Guid customerId, CancellationToken cancellationToken);
    }
}
