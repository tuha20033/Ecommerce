using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class InventoryItemRepository : GenericRepository<InventoryItem>, IInventoryItemRepository
    {
        public InventoryItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
