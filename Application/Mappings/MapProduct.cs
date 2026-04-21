
using Application.DTOs;
using Application.Features.Product.Commands.CreateProductCommandandHandler;
using Domain.Entities;

namespace Application.Mappings;

public class MapProduct : AutoMapper.Profile
{
    public MapProduct()
    {

        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.WareHouse,
                opt => opt.MapFrom(src =>
                    src.InventoryItem != null ? src.InventoryItem.Quantity : 0))

            .ForMember(dest => dest.GroupName,
                opt => opt.MapFrom(src => src.Group.Name));

        CreateMap<CreateProductCommands, Product>();
    }
}
