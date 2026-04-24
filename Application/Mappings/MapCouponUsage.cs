using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapCouponUsage : AutoMapper.Profile
{
    public MapCouponUsage()
    {
        CreateMap<CouponUsage, CouponUsageDTO>().ReverseMap();
    }
}
