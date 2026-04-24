

using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.CouponUsage.Commands.DeleteCoupomUsageCommandHandler
{
    public class DelteCouponUsageCommandHandler : IRequestHandler<DeleteCouponUsageCommand, bool>
    {
        private readonly ILogger<DelteCouponUsageCommandHandler> _logger;
        private readonly ICouponUsageRepository _couponUsageRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DelteCouponUsageCommandHandler(ILogger<DelteCouponUsageCommandHandler> logger, ICouponUsageRepository couponUsageRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _couponUsageRepository = couponUsageRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteCouponUsageCommand request, CancellationToken cancellationToken)
        {
            var couponUsage = await _couponUsageRepository.GetByIdAsync(request.Id, cancellationToken);
            if (couponUsage == null)
            {
                _logger.LogWarning("CouponUsage with id {Id} not found", request.Id);
                return false;
            }
            couponUsage.IsDeleted = true;
            couponUsage.DeletedAt = DateTime.UtcNow;

            await _couponUsageRepository.UpdateAsync(couponUsage, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                _logger.LogInformation("CouponUsage with id {Id} deleted successfully", request.Id);
                return true;
            }

            _logger.LogWarning("Failed to delete CouponUsage with id {Id}", request.Id);
            return false;
        }

    }
}
