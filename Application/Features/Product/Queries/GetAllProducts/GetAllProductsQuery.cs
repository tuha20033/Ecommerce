using Application.Abstractions.Caching;
using Application.DTOs;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductDTO>>, ICacheableQuery
    {
        public string CacheKey => "products-all";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
    }
}
