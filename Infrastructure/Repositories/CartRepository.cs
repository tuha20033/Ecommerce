using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart?> GetByCustomerIdAsync(Guid customerId, CancellationToken ct)
        {
            return await _context.Carts
                .Include(c => c.Items) 
                .FirstOrDefaultAsync(c => c.CustomerId == customerId, ct);
        }
    }
}
