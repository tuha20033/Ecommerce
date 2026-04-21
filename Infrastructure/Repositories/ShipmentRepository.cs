using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Shipment?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
