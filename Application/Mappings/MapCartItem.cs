using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapCartItem : AutoMapper.Profile
{
    public MapCartItem()
    {
        CreateMap<CartItem, CartItemDTO>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.ProductCode))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
            .ReverseMap();
    }
}
