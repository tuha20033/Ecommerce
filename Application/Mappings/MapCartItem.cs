using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapCartItem : AutoMapper.Profile
{
    public MapCartItem()
    {
        CreateMap<CartItem, CartItemDTO>().ReverseMap();
    }
}
