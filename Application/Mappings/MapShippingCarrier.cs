using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapShippingCarrier : AutoMapper.Profile
{
    public MapShippingCarrier()
    {
        CreateMap<ShippingCarrier, ShippingCarrierDTO>().ReverseMap();
    }
}
