

using Application.Abstractions.Caching;
using Application.DTOs;
using MediatR;

namespace Application.Features.Warehouse.Queries.GetAllWarehouse
{
    public class GetAllWarehouseQuery : IRequest<List<WarehouseDTO>>, ICacheableQuery
    {
        public string CacheKey => "warehouses-all";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }
}
