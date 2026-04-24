

using Application.Abstractions.Repositories;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.CouponUsage.Queries.GetAllCouponUsage
{
    public class GetAllCouponUsageQueryHandler : IRequestHandler<GetAllCouponUsageQuery, List<CouponUsageDTO>>
    {
        private readonly ICouponUsageRepository _couponUsageRepository;
        private readonly IMapper mapper;
        public GetAllCouponUsageQueryHandler(ICouponUsageRepository couponUsageRepository, IMapper mapper)
        {
            _couponUsageRepository = couponUsageRepository;
            this.mapper = mapper;
        }
        public Task<List<CouponUsageDTO>> Handle(GetAllCouponUsageQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
