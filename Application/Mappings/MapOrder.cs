using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapOrder : AutoMapper.Profile
{
    public MapOrder()
    {
        CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
            .ReverseMap();
            
        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ReverseMap();
    }
}
