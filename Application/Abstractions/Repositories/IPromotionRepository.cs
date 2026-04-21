

namespace Application.Abstractions.Repositories
{
    public interface IPromotionRepository : IGenericRepository<Domain.Entities.Promotion>
    {
        Task<Domain.Entities.Promotion?> GetValidAsync(string code, CancellationToken cancellationToken);                                       
    }
}
