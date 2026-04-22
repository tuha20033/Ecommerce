

using Application.DTOs;
using MediatR;

namespace Application.Features.Warehouse.Queries.GetByIdWarehouses
{
    public class GetByIdWarehouseQuery : IRequest<WarehouseDTO?>
    {
        public Guid Id { get; set; }

    }
}
