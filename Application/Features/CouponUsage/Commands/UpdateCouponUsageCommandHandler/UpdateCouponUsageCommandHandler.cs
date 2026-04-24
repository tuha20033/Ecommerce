
using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.CouponUsage.Commands.UpdateCouponUsageCommandHandler
{
    public class UpdateCouponUsageCommandHandler : IRequestHandler<UpdateCouponUsageCommand, bool>
    {
        private readonly ILogger<UpdateCouponUsageCommandHandler> _logger;
        private readonly ICouponUsageRepository _couponUsageRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCouponUsageCommandHandler(ILogger<UpdateCouponUsageCommandHandler> logger, ICouponUsageRepository couponUsageRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _couponUsageRepository = couponUsageRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateCouponUsageCommand request, CancellationToken cancellationToken)
        {
            var couponusage = await _couponUsageRepository.GetByIdAsync(request.Id, cancellationToken);
            if (couponusage == null)
            {
                throw new ArgumentNullException(nameof(couponusage));
                
            }
            else
            {   couponusage.Id = request.Id;
                couponusage.CouponId = request.CouponId;
                couponusage.CustomerId = request.CustomerId;
                await _couponUsageRepository.UpdateAsync(couponusage, cancellationToken);

            }
            return true;
        }
    }
}
