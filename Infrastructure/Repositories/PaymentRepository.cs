using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Payment?> GetByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
