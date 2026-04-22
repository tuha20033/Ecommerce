

namespace Application.Mappings
{
    public class MapWarehouse : AutoMapper.Profile
    {
            public MapWarehouse()
            {
                CreateMap<Domain.Entities.Warehouse, Application.DTOs.WarehouseDTO>().ReverseMap();
            CreateMap<Application.Features.Warehouse.Commands.CreateWarehouseCommandandHandler.CreateWareHouseCommand, Domain.Entities.Warehouse>();

        }

    }
}
