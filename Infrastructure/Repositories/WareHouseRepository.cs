using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Data.Persistences;

namespace Infrastructure.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWareHouseRepository
    {
        public WarehouseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
