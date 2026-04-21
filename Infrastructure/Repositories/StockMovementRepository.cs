using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class StockMovementRepository : GenericRepository<StockMovement>, IStockMovementRepository
    {
        public StockMovementRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
