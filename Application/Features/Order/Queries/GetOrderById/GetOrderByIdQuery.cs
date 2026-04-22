using Application.DTOs.Order.ViewOrder;
using MediatR;

namespace Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDTO?>
    {
        public Guid Id { get; set; }
    }
}
