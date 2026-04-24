using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public class MapCoupon : AutoMapper.Profile
{
    public MapCoupon()
    {
        CreateMap<Coupon, CouponDTO>().ReverseMap();
    }
}
