using MediatR;

namespace Application.Features.Review.Commands.ApproveReview
{
    public class ApproveReviewCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
