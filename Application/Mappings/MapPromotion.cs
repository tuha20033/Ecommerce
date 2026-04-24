using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapPromotion : AutoMapper.Profile
{
    public MapPromotion()
    {
        CreateMap<Promotion, PromotionDTO>().ReverseMap();
    }
}
