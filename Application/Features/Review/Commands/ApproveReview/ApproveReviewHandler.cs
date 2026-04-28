using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using MediatR;

namespace Application.Features.Review.Commands.ApproveReview
{
    public class ApproveReviewHandler : IRequestHandler<ApproveReviewCommand, bool>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApproveReviewHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ApproveReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);
            if (review == null) return false;

            review.IsApproved = true;
            await _reviewRepository.UpdateAsync(review, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
