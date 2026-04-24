

using MediatR;

namespace Application.Features.CouponUsage.Commands.DeleteCoupomUsageCommandHandler
{
    public class DeleteCouponUsageCommand: IRequest<bool>
    {
        public Guid Id { get; set; }

    }
}
