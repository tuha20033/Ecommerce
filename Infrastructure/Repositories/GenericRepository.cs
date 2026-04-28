
using Application.Abstractions.Repositories;
using Infrastructure.Data.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> Set;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            //Set = _context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken ct)
        {
           await _context.Set<T>().AddAsync(entity,ct);
            ////await _context.SaveChangesAsync(ct);

        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var existing = await  GetByIdAsync(id, ct);
            if (existing is not null)
            {
                _context.Set<T>().Remove(existing);
                //await _context.SaveChangesAsync(ct);
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id, ct);
        }

        public async Task UpdateAsync(T entity, CancellationToken ct)
        {
            _context.Set<T>().Update(entity);
            //await _context.SaveChangesAsync(ct);

        }
    }
}
