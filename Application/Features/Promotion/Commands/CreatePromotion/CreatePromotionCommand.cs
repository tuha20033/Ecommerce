using Domain.Enums;
using MediatR;

namespace Application.Features.Promotion.Commands.CreatePromotion
{
    public class CreatePromotionCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public PromotionType Type { get; set; }
        public decimal Value { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxDiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
