using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapStockMovement : AutoMapper.Profile
{
    public MapStockMovement()
    {
        CreateMap<StockMovement, StockMovementDTO>().ReverseMap();
    }
}
