using Application.DTOs;
using MediatR;

namespace Application.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<OrderDTO>> { }
}
