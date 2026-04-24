

using Application.DTOs;
using MediatR;

namespace Application.Features.CartItem.Queries.GetByIdCartItem
{
    public class GetByIdCartItemQuery : IRequest<CartItemDTO?>
    {
        public Guid Id { get; set; }
    }
}
