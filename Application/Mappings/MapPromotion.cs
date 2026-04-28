using Application.DTOs;
using Application.Features.Promotion.Commands.CreatePromotion;
using Domain.Entities;

namespace Application.Mappings;

public class MapPromotion : AutoMapper.Profile
{
    public MapPromotion()
    {
        CreateMap<Promotion, PromotionDTO>().ReverseMap();
        CreateMap<CreatePromotionCommand, Promotion>();
    }
}
