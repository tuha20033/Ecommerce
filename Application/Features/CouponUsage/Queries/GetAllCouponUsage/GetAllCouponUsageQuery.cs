

using Application.DTOs;
using MediatR;

namespace Application.Features.CouponUsage.Queries.GetAllCouponUsage
{
    public  class GetAllCouponUsageQuery : IRequest<List<CouponUsageDTO>>
    {
    }
}
