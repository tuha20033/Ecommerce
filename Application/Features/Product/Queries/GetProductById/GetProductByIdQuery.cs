using Application.Abstractions.Caching;
using Application.DTOs;
using MediatR;

namespace Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDTO?>, ICacheableQuery
    {
        public Guid Id { get; set; }

        public string CacheKey => $"product-{Id}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(3);
    }
}
