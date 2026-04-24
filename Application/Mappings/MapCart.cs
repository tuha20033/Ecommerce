using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapCart : AutoMapper.Profile
{
    public MapCart()
    {
        CreateMap<Cart, CartDTO>().ReverseMap();
    }
}
