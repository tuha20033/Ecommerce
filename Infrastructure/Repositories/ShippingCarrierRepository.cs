using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class ShippingCarrierRepository : GenericRepository<ShippingCarrier>, IShippingCarrierRepository
    {
        public ShippingCarrierRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
