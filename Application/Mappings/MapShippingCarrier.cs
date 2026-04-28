using Application.DTOs;
using Application.Features.ShippingCarrier.Commands.CreateShippingCarrier;
using Domain.Entities;

namespace Application.Mappings;

public class MapShippingCarrier : AutoMapper.Profile
{
    public MapShippingCarrier()
    {
        CreateMap<ShippingCarrier, ShippingCarrierDTO>().ReverseMap();
        CreateMap<CreateShippingCarrierCommand, ShippingCarrier>();
    }
}
