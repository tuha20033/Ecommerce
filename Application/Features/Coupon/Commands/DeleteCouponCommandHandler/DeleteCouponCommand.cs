

using MediatR;

namespace Application.Features.Coupon.Commands.DeleteCouponCommandHandler
{
    public class DeleteCouponCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
