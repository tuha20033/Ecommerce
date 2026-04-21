

using Application.Abstractions.UnitOfWork;
using Infrastructure.Data.Persistences;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
   
        public UnitOfWorkRepository( ApplicationDbContext context)
        {
            _context = context;
       
        }
        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
           return await _context.SaveChangesAsync(ct);
        }
    }
}
