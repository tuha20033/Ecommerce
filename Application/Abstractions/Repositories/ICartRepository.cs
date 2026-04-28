
namespace Application.Abstractions.Repositories
{
    public interface ICartRepository : IGenericRepository<Domain.Entities.Cart>
    {
        Task<Domain.Entities.Cart?> GetByCustomerIdAsync(Guid customerId, CancellationToken ct);
    }
}
