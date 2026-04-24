
using MediatR;

namespace Application.Features.CouponUsage.Commands.UpdateCouponUsageCommandHandler
{
    public class UpdateCouponUsageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime UsedAt { get; set; }
    }
}
