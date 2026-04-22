

using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Warehouse.Queries.GetAllWarehouse
{
    public class GetAllWarehousesHandler : IRequestHandler<GetAllWarehouseQuery, List<WarehouseDTO>>
    {
        private readonly IWareHouseRepository _warehousereposity;
        private readonly IMapper _mapper;
        public GetAllWarehousesHandler(IWareHouseRepository warehousereposity, IMapper mapper)
        {
            _warehousereposity = warehousereposity;
            _mapper = mapper;
        }
        public async Task<List<WarehouseDTO>> Handle(GetAllWarehouseQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _warehousereposity.GetAllAsync(cancellationToken);
            return _mapper.Map<List<WarehouseDTO>>(warehouses);
        }
    }
}
