using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapShipment : AutoMapper.Profile
{
    public MapShipment()
    {
        CreateMap<Shipment, ShipmentDTO>().ReverseMap();
    }
}
