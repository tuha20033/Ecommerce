using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.Promotion.Commands.UpdatePromotion
{
    public class UpdatePromotionHandler : IRequestHandler<UpdatePromotionCommand, bool>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePromotionHandler(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork)
        {
            _promotionRepository = promotionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (promotion == null) return false;

            promotion.Name = request.Name;
            promotion.Description = request.Description;
            promotion.Type = request.Type;
            promotion.Value = request.Value;
            promotion.MinOrderAmount = request.MinOrderAmount;
            promotion.MaxDiscountAmount = request.MaxDiscountAmount;
            promotion.StartDate = request.StartDate;
            promotion.EndDate = request.EndDate;
            promotion.IsActive = request.IsActive;

            await _promotionRepository.UpdateAsync(promotion, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
