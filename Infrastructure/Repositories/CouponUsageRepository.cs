
using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class CouponUsageRepository : GenericRepository<CouponUsage>, ICouponUsageRepository
    {
        public CouponUsageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
