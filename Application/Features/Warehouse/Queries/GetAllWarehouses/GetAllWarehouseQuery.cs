

using Application.DTOs;
using MediatR;

namespace Application.Features.Warehouse.Queries.GetAllWarehouse
{
    public class GetAllWarehouseQuery : IRequest<List<WarehouseDTO>>
    {

    }
}
