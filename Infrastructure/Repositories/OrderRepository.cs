using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Order>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetDetailAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
