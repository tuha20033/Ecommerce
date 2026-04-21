using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Promotion?> GetValidAsync(string code, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
