using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
