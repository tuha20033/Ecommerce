
using Domain.Entities;
using Infrastructure.Data.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Domain.Entities.Product>, Application.Abstractions.Repositories.IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
  
        public async Task<List<Product>> GetActiveAsync(CancellationToken cancellationToken)
        {
            // Lây sản phẩm đang hoạt động 
          return await _context.Products
                .AsNoTracking()
                .Where(p => p.IsActive)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllWithDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.Products
        .AsNoTracking()
        .Include(p => p.InventoryItem)
        .Include(p => p.Group)
        .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByCodeAsync(string productCode, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductCode == productCode, cancellationToken);
        }

        public async  Task<List<Product>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            // thằng này là để tạo order , load nhiefu sản phẩm , giỏ hàng card 
            return  await _context.Products
                .AsNoTracking()
                .Where(p => ids.Contains(p.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<(List<Product>, int total)> GetPageAsync(int pageNumber, int pageSize, string? keyword, CancellationToken cancellationToken)
        {
            // thằng này là đẻ phân trang và search 
           var query = _context.Products.AsNoTracking();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword) || p.ProductCode.Contains(keyword));
            }
            var total = await query.CountAsync(cancellationToken);
            var Product = await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

            return (Product, total);
        }

        public Task<Product?> GetWithInventoryAsync(Guid id, CancellationToken cancellationToken)
        {
           return _context.Products
                .Include(p => p.InventoryItem)
                 .Include(p => p.Group)

                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
    }
}
