

namespace Application.Abstractions.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Domain.Entities.Payment>
    {
         Task<Domain.Entities.Payment?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken);
    }
}
