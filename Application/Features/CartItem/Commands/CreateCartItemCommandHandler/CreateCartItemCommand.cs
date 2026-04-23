
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.CartItem.Commands.CreateCartItemCommandHandler
{
    public class CreateCartItemCommand : IRequest<Guid>
    {
        public Guid CartId { get; set; }
   
        public Guid ProductId { get; set; }
    
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
