

using MediatR;

namespace Application.Features.Cart.Commands.CreatCartCommamdHandler
{
    public class CreateCartCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;

    }
}
