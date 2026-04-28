
using Application.Abstractions.Caching;
using Application.DTOs;
using MediatR;

namespace Application.Features.Cart.Queries.GetCartById
{
    public class GetByIdQuery : IRequest<CartDTO?>, ICacheableQuery
    {
        public Guid Id { get; set; }

        public string CacheKey => $"cart-id:{Id}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}