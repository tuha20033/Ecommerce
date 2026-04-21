using Application.DTOs;
using MediatR;

namespace Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDTO?>
    {
        public Guid Id { get; set; }
        public GetOrderByIdQuery(Guid id) => Id = id;
    }
}
