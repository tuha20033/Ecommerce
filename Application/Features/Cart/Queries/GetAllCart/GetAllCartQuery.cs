
using Application.Abstractions.Caching;
using Application.DTOs;
using MediatR;

namespace Application.Features.Cart.Queries.GetAllCart
{
    public class GetAllCartQuery : IRequest<CartDTO?>, ICacheableQuery
    {
        public Guid CustomerId { get; set; }

        public string CacheKey => $"cart:{CustomerId}";
        public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
    }
}