using Domain.Enums;
using MediatR;

namespace Application.Features.Order.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
