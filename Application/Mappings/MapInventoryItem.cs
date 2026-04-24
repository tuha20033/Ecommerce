using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapInventoryItem : AutoMapper.Profile
{
    public MapInventoryItem()
    {
        CreateMap<InventoryItem, InventoryItemDTO>().ReverseMap();
    }
}
