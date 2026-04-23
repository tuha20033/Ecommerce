
using MediatR;

namespace Application.Features.CartItem.Commands.UpdateCartItemCommandHandler
{
    public class UpdateCartItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
