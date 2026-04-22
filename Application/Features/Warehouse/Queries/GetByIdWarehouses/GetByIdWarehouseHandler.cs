

using Application.Abstractions.Repositories;
using Application.DTOs;
using MediatR;

namespace Application.Features.Warehouse.Queries.GetByIdWarehouses
{
    public class GetByIdWarehouseHandler : IRequestHandler<GetByIdWarehouseQuery, WarehouseDTO?>
    {
        private readonly IWareHouseRepository _warehouseRepository;
        public GetByIdWarehouseHandler(IWareHouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task<WarehouseDTO?> Handle(GetByIdWarehouseQuery request, CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty)
            {
                throw new ArgumentException("Id cannot be empty.");
            }
           var warehouse = await  _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (warehouse is not null)
            {
                return new WarehouseDTO
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    Address = warehouse.Address,
                    Phone = warehouse.Phone,
                    IsActive = warehouse.IsActive
                };

            }
            else
            {
             throw new Exception($"Warehouse with id {request.Id} not found.");
            }

        }
    }
}
