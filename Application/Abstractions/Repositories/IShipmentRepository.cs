

namespace Application.Abstractions.Repositories
{
    public interface IShipmentRepository : IGenericRepository<Domain.Entities.Shipment>
    {
        Task<Domain.Entities.Shipment?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken);
    }
}
