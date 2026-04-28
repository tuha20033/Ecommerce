using Application.DTOs;
using MediatR;

namespace Application.Features.Review.Queries.GetAllReviews
{
    public class GetAllReviewsQuery : IRequest<List<ReviewDTO>>
    {
    }
}
